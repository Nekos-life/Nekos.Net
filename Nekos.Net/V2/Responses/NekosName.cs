using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

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