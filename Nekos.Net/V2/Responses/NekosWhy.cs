using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Represents for /why endpoint response.
/// </summary>
public class NekosWhy
{
    /// <summary>
    ///     Random why question.
    /// </summary>
    [JsonProperty("why")] public string Why;
}