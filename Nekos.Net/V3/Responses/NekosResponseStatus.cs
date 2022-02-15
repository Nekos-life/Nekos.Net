#nullable enable
using Newtonsoft.Json;

namespace Nekos.Net.V3.Responses;

/// <summary>
///     Response status.
/// </summary>
[JsonObject("status")]
public class NekosResponseStatus
{
    /// <summary>
    ///     The time in second the server took to create the response.
    /// </summary>
    [JsonProperty("rendered_in")]
    public double RenderedIn;
    
    /// <summary>
    ///     Error message, null if <see cref="IsSuccess"/> is true, text otherwise.
    /// </summary>
    [JsonProperty("message", NullValueHandling = NullValueHandling.Include)]
    public string? ErrorMessage;
    
    /// <summary>
    ///     Response status code.
    /// </summary>
    [JsonProperty("code")]
    public int StatusCode;
    
    /// <summary>
    ///     If there was something wrong with the response or not.
    /// </summary>
    [JsonProperty("success")]
    public bool IsSuccess;
}