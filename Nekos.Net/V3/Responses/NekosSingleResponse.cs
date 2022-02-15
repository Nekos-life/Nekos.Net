using Newtonsoft.Json;

namespace Nekos.Net.V3.Responses;

/// <summary>
///     Response data with one image/GIF URL returned.
/// </summary>
public class NekosSingleResponse
{
    /// <summary>
    ///     <inheritdoc cref="NekosSingleResponseData"/>
    /// </summary>
    [JsonProperty("data")]
    public NekosSingleResponseData Data;

    /// <summary>
    ///     <inheritdoc cref="NekosResponseStatus"/>
    /// </summary>
    [JsonProperty("status")]
    public NekosResponseStatus Status;
}

/// <summary>
///     Response data.
/// </summary>
[JsonObject("data")]
public class NekosSingleResponseData
{
    /// <summary>
    ///     <inheritdoc cref="NekosSingleResponseDataResponse"/>
    /// </summary>
    [JsonProperty("response")]
    public NekosSingleResponseDataResponse Response;
}

/// <summary>
///     Actual response.
/// </summary>
[JsonObject("response")]
public class NekosSingleResponseDataResponse
{
    /// <summary>
    ///     Provided Image/GIF URL.
    /// </summary>
    [JsonProperty("url")]
    public string Url;
}