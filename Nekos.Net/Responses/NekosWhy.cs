using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /why endpoint.
    /// </summary>
    public class NekosWhy
    {
        /// <summary>
        ///     Random why question.
        /// </summary>
        [JsonProperty("why")] 
        public string Why;
    }
}