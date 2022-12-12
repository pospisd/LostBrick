using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record SetPiece(
    /// <summary></summary>
    [property: JsonProperty("part", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("part")] SetPart Part,

    /// <summary></summary>
    [property: JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("quantity")] int? Quantity
);
