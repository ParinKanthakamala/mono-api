using System.Net;
using Newtonsoft.Json;

namespace Web.Shared.Libraries.Endpoints
{
    public class ResponseMessage
    {
        [JsonProperty("message")] public string Message { get; set; } = "Unsupported get request.";
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("code")] public HttpStatusCode Code { get; set; } = HttpStatusCode.BadRequest;
    }
}