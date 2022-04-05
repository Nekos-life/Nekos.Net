using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

public class NekosCat
{
    /// <summary>
    ///     Why question.
    /// </summary>
    [JsonProperty("cat")] public string Cat;
}