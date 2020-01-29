using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /8ball endpoint.
    /// </summary>
    public class Nekos8Ball
    {
        /// <summary>
        ///     8 ball response.
        /// </summary>
        [JsonProperty("response")] public string Response;

        /// <summary>
        ///     8 ball image URL.
        /// </summary>
        [JsonProperty("url")] public string Url;
    }
}