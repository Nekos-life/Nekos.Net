using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Represents for /fact endpoint response.
/// </summary>
public class NekosFact
{
    /// <summary>
    ///     Random fact.
    /// </summary>
    [JsonProperty("fact")] public string Fact;
}