using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record Brick(
    /// <summary></summary>
    [property: JsonProperty("pieceId", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("pieceId")] string PieceId,

    /// <summary></summary>
    [property: JsonProperty("variants", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("variants")] IReadOnlyList<BrickVariant> Variants
);


