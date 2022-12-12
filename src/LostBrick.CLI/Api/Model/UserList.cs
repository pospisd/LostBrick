using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record UserList(
    /// <summary></summary>
    [property: JsonProperty("Users", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("Users")] IReadOnlyList<User> Users
);


