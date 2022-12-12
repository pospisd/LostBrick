using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record ColorList(
    /// <summary></summary>
    [property: JsonProperty("colours", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("colours")] IReadOnlyList<Color> Colors
);
