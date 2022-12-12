using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record Color(
    /// <summary></summary>
    [property: JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("name")] string Name,

    /// <summary></summary>
    [property: JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("code")] int? Code
);
