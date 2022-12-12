using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record BrickVariant(
    /// <summary></summary>
    [property: JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("color")] string Color,

    /// <summary></summary>
    [property: JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("count")] int? Count
);


