using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nekos.Net.V3.Responses;

public class NekosListedResponse
{
    [JsonProperty("data")]
    public NekosResponseListData Data;
    
    [JsonProperty("status")]
    public NekosResponseListData Status;
}

[JsonObject("data")]
public class NekosResponseListData
{
    [JsonProperty("response")]
    public NekosResponseListDataResponse Response;
}

[JsonObject("response")]
public class NekosResponseListDataResponse
{
    [JsonProperty("urls")]
    public List<string> Urls;
}

[JsonObject("status")]
public class NekosResponseListStatus
{
    [JsonProperty("rendered_in")]
    public double RenderedIn;
    
    [JsonProperty("message")]
    public int RequestMessage;
    
    [JsonProperty("code")]
    public int StatusCode;
    
    [JsonProperty("success")]
    public bool Success;
}