using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version3
{
    public class NekosResponseList
    {
        [JsonProperty("data")] public NekosResponseListData Data;
        [JsonProperty("status")] public NekosResponseListData Status;
    }
    
    [JsonObject("data")]
    public class NekosResponseListData
    {
        [JsonProperty("response")] public NekosResponseListDataResponse Response;
    }
    
    [JsonObject("response")]
    public class NekosResponseListDataResponse
    {
        [JsonProperty("urls")] public string[] Url;
    }
    
    [JsonObject("status")]
    public class NekosResponseListStatus
    {
        [JsonProperty("rendered_in")] public double RenderedIn;
        [JsonProperty("message")] public int RequestMessage;
        [JsonProperty("code")] public int StatusCode;
        [JsonProperty("success")] public bool Success;
    }
}