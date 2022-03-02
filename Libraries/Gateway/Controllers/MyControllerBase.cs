using Newtonsoft.Json;

namespace Gateway.Controllers
{
    public class MyControllerBase
    {
        public DataMessage message = Sharepoint.sharepoint.message;
        public Sharepoint sharepoint = Sharepoint.sharepoint;

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