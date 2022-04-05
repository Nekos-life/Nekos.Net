using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

public class NekosCat
{
    /// <summary>
    ///     ASCII cat text.
    /// </summary>
    [JsonProperty("cat")] public string Cat;
}