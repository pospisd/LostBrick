using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record User(
    /// <summary></summary>
    [property: JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("id")] Guid Id,

    /// <summary></summary>
    [property: JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("username")] string Username,

    /// <summary></summary>
    [property: JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("location")] string Location,

    /// <summary></summary>
    [property: JsonProperty("brickCount", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("brickCount")] int? BrickCount,

    /// <summary></summary>
    [property: JsonProperty("collection", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("collection")] IReadOnlyList<Brick> Collection
);
