using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /img endpoint.
    /// </summary>
    public class NekosImage
    {
        /// <summary>
        ///     The image/GIF URL depends on your search.
        /// </summary>
        [JsonProperty("url")] 
        public string FileUrl;
    }
}