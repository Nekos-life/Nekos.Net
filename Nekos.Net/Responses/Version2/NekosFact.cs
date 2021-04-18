using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version2
{
    /// <summary>
    ///     Represents for /fact endpoint response.
    /// </summary>
    public class NekosFact
    {
        /// <summary>
        ///     Random fact.
        /// </summary>
        [JsonProperty("fact")] public string Fact;
    }
}