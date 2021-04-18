using Newtonsoft.Json;

namespace Nekos.Net.Responses.Version3
{
    public class NekosResponse
    {
        [JsonProperty("data")] public NekosResponseData Data;
        [JsonProperty("status")] public NekosResponseStatus Status;
    }
    
    [JsonObject("data")]
    public class NekosResponseData
    {
        [JsonProperty("response")] public NekosResponseDataResponse Response;
    }
    
     [JsonObject("response")]
     public class NekosResponseDataResponse
     {
         [JsonProperty("url")] public string Url;
     }
    
     [JsonObject("status")]
     public class NekosResponseStatus
     {
         [JsonProperty("rendered_in")] public double RenderedIn;
         [JsonProperty("message")] public int RequestMessage;
         [JsonProperty("code")] public int StatusCode;
         [JsonProperty("success")] public bool Success;
     }
}