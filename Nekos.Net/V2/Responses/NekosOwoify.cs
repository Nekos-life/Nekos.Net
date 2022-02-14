using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Represents for /owoify and /spoiler endpoint response.
/// </summary>
public class NekosOwoify
{
    /// <summary>
    ///     The owoified string or spoiler
    /// </summary>
    [JsonProperty("owo")] public string Owo;
}