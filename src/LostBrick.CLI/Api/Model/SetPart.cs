using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record SetPart(
    /// <summary></summary>
    [property: JsonPropertyName("designID")] string DesignID,

    /// <summary></summary>
    [property: JsonPropertyName("material")] int? Material
);
