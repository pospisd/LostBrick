using LostBrick.Cli.Api.Model;
using Refit;


namespace LostBrick.CLI.Api;

/// <summary></summary>
public interface ILegoApiClient
{
    /// <summary></summary>
    /// <returns>a list of users in the catalogue</returns>
    [Get("/api/users")]
    Task<UserList> GetUsers();

    /// <summary></summary>
    /// <param name="username"></param>
    /// <returns>a summary of a single user</returns>
    [Get("/api/user/by-username/{username}")]
    Task<UserInfo> GetUserByName(string username);

    /// <summary></summary>
    /// <param name="id"></param>
    /// <returns>the full data for a single user</returns>
    [Get("/api/user/by-id/{id}")]
    Task<User> GetUserById(Guid id);

    /// <summary></summary>
    /// <returns>a list of the sets in the catalogue</returns>
    [Get("/api/sets")]
    Task<SetList> GetSets();

    /// <summary></summary>
    /// <param name="name"></param>
    /// <returns>a summary of a single set</returns>
    [Get("/api/set/by-name/{name}")]
    Task<SetInfo> GetSetByName(string name);

    /// <summary></summary>
    /// <param name="id"></param>
    /// <returns>the full data for a single set</returns>
    [Get("/api/set/by-id/{id}")]
    Task<Set> GetSetById(Guid id);

    /// <summary></summary>
    /// <returns>the full list of colours available</returns>
    [Get("/api/colours")]
    Task<ColorList> GetColors();
}
