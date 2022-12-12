using LostBrick.Cli.Api.Model;
using LostBrick.CLI.Api;
using System.Collections.Concurrent;


namespace LostBrick.Cli;

/// <summary></summary>
public sealed class BrickService
{
    private readonly ILegoApiClient _apiClient;

    /// <summary></summary>
    /// <param name="apiClient"></param>
    public BrickService(ILegoApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary></summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<IEnumerable<string>> FindBuildableSets(string username)
    {
        var userInfo = await _apiClient.GetUserByName(username);
        return await FindBuildableSets(userInfo.Id);
    }

    private async Task<IList<string>> FindBuildableSets(Guid userId)
    {
        var userTask = _apiClient.GetUserById(userId);
        var setInfoTask = _apiClient.GetSets();

        await Task.WhenAll(new Task[] { userTask, setInfoTask });

        var user = userTask.Result;

        var collection = user.Collection
            .SelectMany(b => b.Variants.Select(v => new { DesigId = b.PieceId, v.Color, v.Count }))
            .ToDictionary(k => new SetPart(k.DesigId, int.Parse(k.Color)), v => v.Count);

        var sets = setInfoTask.Result.Sets
            .Where(info => info.TotalPieces <= user.BrickCount);

        return await FindBuildableSets(collection, sets);
    }

    private async Task<IList<string>> FindBuildableSets(IDictionary<SetPart,int?> collection, IEnumerable<SetInfo> setsInfo)
    {
        var result = new ConcurrentQueue<string>();
        var cts = new CancellationTokenSource();
        var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };

        try
        {
            await Parallel.ForEachAsync(setsInfo, options, async (info, cts) =>
            {
                var set = await _apiClient.GetSetById(info.Id);
                bool canBeBuild = CanBeBuild(collection, set.Pieces);
                if (canBeBuild) result.Enqueue(set.Name);
            });
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            cts.Dispose();
        }
        
        return result.ToList();
    }

    private static bool CanBeBuild(IDictionary<SetPart, int?> collection, IEnumerable<SetPiece> Pieces)
    {
        return Pieces.All(p =>
            collection.TryGetValue(p.Part, out int? count)
            ? p.Quantity <= count
            : false);
    }

    /// <summary></summary>
    /// <param name="username"></param>
    /// <param name="setName"></param>
    /// <returns></returns>
    public async Task<IList<string>> FindBuddyToBuild(string username, string setName)
    {
        var userInfoTask = _apiClient.GetUserByName(username);
        var setInfoTask = _apiClient.GetSetByName(setName);

        await Task.WhenAll(new Task[] { userInfoTask, setInfoTask });

        var setTask = _apiClient.GetSetById(setInfoTask.Result.Id);
        var userTask = _apiClient.GetUserById(userInfoTask.Result.Id);

        await Task.WhenAll(new Task[] { userInfoTask, setInfoTask });

        return await FindBuddyToBuild(userTask.Result, setTask.Result);
    }

    private async Task<IList<string>> FindBuddyToBuild(User user, Set set)
    {
        var userParts = user.Collection.SelectMany(b => b.Variants.Select(v => new { Part = new SetPart(b.PieceId, int.Parse(v.Color)), v.Count }));

        var missingParts = set.Pieces
            .Join(userParts, p => p.Part, p => p.Part, (p, u) => new { p.Part, Needed = p.Quantity - u.Count })
            .Where(p => p.Needed  > 0)
            .Select(p => new SetPiece(p.Part,p.Needed))
            .ToList();

        var usersInfo = await _apiClient.GetUsers();

        var result = new ConcurrentQueue<string>();
        var cts = new CancellationTokenSource();
        var options = new ParallelOptions { MaxDegreeOfParallelism = 4 };

        try
        {
            await Parallel.ForEachAsync(usersInfo.Users.Where(u=>u.Id != user.Id), options, async (info, cts) =>
            {
                var buddy = await _apiClient.GetUserById(info.Id);
                
                var collection = buddy.Collection
                    .SelectMany(b => b.Variants.Select(v => new { DesigId = b.PieceId, v.Color, v.Count }))
                    .ToDictionary(k => new SetPart(k.DesigId, int.Parse(k.Color)), v => v.Count);
                
                bool canBeBuild = CanBeBuild(collection, missingParts);
                if (canBeBuild) result.Enqueue(buddy.Username);
            });
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            cts.Dispose();
        }

        return result.ToList();
    }
}