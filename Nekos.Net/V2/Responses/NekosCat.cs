using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for why-question requests.
/// </summary>
public class NekosCat
{
    /// <summary>
    ///     Why question.
    /// </summary>
    [JsonProperty("cat")] public string Cat;
}