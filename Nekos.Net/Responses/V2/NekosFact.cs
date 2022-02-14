using Newtonsoft.Json;

namespace Nekos.Net.Responses.V2;

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