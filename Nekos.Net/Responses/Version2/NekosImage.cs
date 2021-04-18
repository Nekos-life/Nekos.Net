using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version2
{
    /// <summary>
    ///     Represents for /img endpoint response.
    /// </summary>
    public class NekosImage
    {
        /// <summary>
        ///     The image/GIF URL depends on your search.
        /// </summary>
        [JsonProperty("url")] public string Url;
    }
}