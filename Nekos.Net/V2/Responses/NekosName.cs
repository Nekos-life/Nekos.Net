using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for name requests.
/// </summary>
public class NekosName
{
    /// <summary>
    ///     A random name.
    /// </summary>
    [JsonProperty("name")] public string Name;
}