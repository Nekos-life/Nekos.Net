using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version2
{
    /// <summary>
    ///     Represents for /img endpoint response.
    /// </summary>
    public class NekosName
    {
        /// <summary>
        ///     A random name.
        /// </summary>
        [JsonProperty("name")] public string Name;
    }
}