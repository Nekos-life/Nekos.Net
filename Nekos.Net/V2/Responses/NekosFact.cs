using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for fact requests.
/// </summary>
public class NekosFact
{
    /// <summary>
    ///     Random fact.
    /// </summary>
    [JsonProperty("fact")] public string Fact;
}