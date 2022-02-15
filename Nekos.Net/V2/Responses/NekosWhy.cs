using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for why-question requests.
/// </summary>
public class NekosWhy
{
    /// <summary>
    ///     Why question.
    /// </summary>
    [JsonProperty("why")] public string Why;
}