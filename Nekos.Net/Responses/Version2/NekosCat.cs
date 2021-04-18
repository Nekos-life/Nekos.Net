using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version2
{
    /// <summary>
    ///     Represents for /cat endpoint response.
    /// </summary>
    public class NekosCat
    {
        /// <summary>
        ///     Cat emoji like ٩(ↀДↀ)۶.
        /// </summary>
        [JsonProperty("cat")] public string Cat;
    }
}