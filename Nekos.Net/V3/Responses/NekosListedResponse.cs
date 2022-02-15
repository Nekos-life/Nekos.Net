using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nekos.Net.V3.Responses;

/// <summary>
///     Response data with multiple image/GIF URLs returned.
/// </summary>
public class NekosListedResponse
{
    /// <summary>
    ///     <inheritdoc cref="NekosSingleResponseData"/>
    /// </summary>
    [JsonProperty("data")]
    public NekosListedResponseData Data;
    
    /// <summary>
    ///     <inheritdoc cref="NekosResponseStatus"/>
    /// </summary>
    [JsonProperty("status")]
    public NekosResponseStatus Status;
}

/// <summary>
///     <inheritdoc cref="NekosSingleResponseData"/>
/// </summary>
[JsonObject("data")]
public class NekosListedResponseData
{
    /// <summary>
    ///     <inheritdoc cref="NekosSingleResponseDataResponse"/>
    /// </summary>
    [JsonProperty("response")]
    public NekosListedResponseDataResponse Response;
}

/// <summary>
///     <inheritdoc cref="NekosSingleResponseDataResponse"/>
/// </summary>
[JsonObject("response")]
public class NekosListedResponseDataResponse
{
    /// <summary>
    ///     Provided Image/GIF URLs.
    /// </summary>
    [JsonProperty("urls")]
    public List<string> Urls;
}