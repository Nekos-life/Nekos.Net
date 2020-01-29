using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /cat endpoint.
    /// </summary>
    public class NekosCat
    {
        /// <summary>
        ///     Cat emoji like ٩(ↀДↀ)۶.
        /// </summary>
        [JsonProperty("cat")] public string Cat;
    }
}