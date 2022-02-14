using Newtonsoft.Json;

namespace Nekos.Net.V3.Responses;

public class NekosSingleResponse
{
    [JsonProperty("data")]
    public NekosSingleResponseData Data;
    
    [JsonProperty("status")]
    public NekosSingleResponseStatus Status;
}

[JsonObject("data")]
public class NekosSingleResponseData
{
    [JsonProperty("response")]
    public NekosSingleResponseDataResponse Response;
}

[JsonObject("response")]
public class NekosSingleResponseDataResponse
{
    [JsonProperty("url")]
    public string Url;
}

[JsonObject("status")]
public class NekosSingleResponseStatus
{
    [JsonProperty("rendered_in")] public double RenderedIn;
    [JsonProperty("message")] public int RequestMessage;
    [JsonProperty("code")] public int StatusCode;
    [JsonProperty("success")] public bool Success;
}