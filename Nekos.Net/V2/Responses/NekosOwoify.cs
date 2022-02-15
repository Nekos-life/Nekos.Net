using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for OwO-ify/spoiler requests.
/// </summary>
public class NekosOwoify
{
    /// <summary>
    ///     The OwO-ified/spoiler-covered text.
    /// </summary>
    [JsonProperty("owo")] public string OwO;
}