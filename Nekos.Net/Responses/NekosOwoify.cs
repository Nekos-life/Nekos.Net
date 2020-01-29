using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /owoify and /spoiler endpoint.
    /// </summary>
    public class NekosOwoify
    {
        /// <summary>
        ///     The owoified string.
        ///     Or Discord spoiler-covered text
        /// </summary>
        [JsonProperty("owo")] 
        public string OwoString;
    }
}