using Newtonsoft.Json;

namespace Gateway.Controllers
{
    public class ControllerBase
    {
        public Sharepoint sharepoint = Sharepoint.sharepoint;
        public DataMessage message = Sharepoint.sharepoint.message;

        public string Result(object sender)
        {
            return JsonConvert.SerializeObject(sender);
        }

        public string Json(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}