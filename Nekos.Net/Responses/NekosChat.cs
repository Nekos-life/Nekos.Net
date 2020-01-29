using Newtonsoft.Json;

namespace Nekos.Net.Responses
{
    /// <summary>
    ///     Represents for /chat endpoint.
    /// </summary>
    public class NekosChat
    {
        /// <summary>
        ///     The chat response.
        /// </summary>
        [JsonProperty("response")] 
        public string Response;
    }
}