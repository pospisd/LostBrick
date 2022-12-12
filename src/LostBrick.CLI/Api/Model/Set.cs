using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record Set(
    /// <summary></summary>
    [property: JsonPropertyName("id")] Guid Id,

    /// <summary></summary>
    [property: JsonPropertyName("name")] string Name,

    /// <summary></summary>
    [property: JsonPropertyName("setNumber")] string SetNumber,

    /// <summary></summary>
    [property: JsonPropertyName("pieces")] IReadOnlyList<SetPiece> Pieces,

    /// <summary></summary>
    [property: JsonPropertyName("totalPieces")] int? TotalPieces
);
