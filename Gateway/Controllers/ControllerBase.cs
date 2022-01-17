using Newtonsoft.Json;

namespace Gateway.Controllers
{
    public class ControllerBase
    {
        public Sharepoint sharepoint = Sharepoint.sharepoint;
        public DataMessage message = Sharepoint.sharepoint.message;

        public void Result(object sender)
        {
            sharepoint.server.Send(message: JsonConvert.SerializeObject(sender), kick: true);
        }

        public string Json(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}