using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for 8ball requests.
/// </summary>
public class Nekos8Ball
{
    /// <summary>
    ///     8 ball response.
    /// </summary>
    [JsonProperty("response")] public string Response;

    /// <summary>
    ///     8 ball image URL.
    /// </summary>
    [JsonProperty("url")] public string Url;
}