using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LostBrick.Cli.Api.Model;

/// <summary></summary>
public record SetList(
    /// <summary></summary>
    [property: JsonProperty("Sets", NullValueHandling = NullValueHandling.Ignore)]
    [property: JsonPropertyName("Sets")] IReadOnlyList<SetInfo> Sets
);
