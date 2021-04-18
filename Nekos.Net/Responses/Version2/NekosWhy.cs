using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version2
{
    /// <summary>
    ///     Represents for /why endpoint response.
    /// </summary>
    public class NekosWhy
    {
        /// <summary>
        ///     Random why question.
        /// </summary>
        [JsonProperty("why")] public string Why;
    }
}