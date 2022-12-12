using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record SetInfo(
    /// <summary></summary>
    [property: JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("id")] Guid Id,

    /// <summary></summary>
    [property: JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("name")] string Name,

    /// <summary></summary>
    [property: JsonProperty("setNumber", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("setNumber")] string SetNumber,

    /// <summary></summary>
    [property: JsonProperty("totalPieces", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("totalPieces")] int? TotalPieces
);
