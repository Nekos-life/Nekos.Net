using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /chat endpoint.
    /// </summary>
    public class NekosFact
    {
        /// <summary>
        ///     Random fact.
        /// </summary>
        [JsonProperty("fact")] 
        public string Fact;
    }
}