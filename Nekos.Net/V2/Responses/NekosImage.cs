using Newtonsoft.Json;

namespace Nekos.Net.V2.Responses;

/// <summary>
///     Response object for image requests.
/// </summary>
public class NekosImage
{
    /// <summary>
    ///     Image/GIF URL.
    /// </summary>
    [JsonProperty("url")] public string Url;
}