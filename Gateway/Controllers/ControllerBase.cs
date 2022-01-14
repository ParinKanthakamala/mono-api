using System;
using Gateway.Routing;
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    public class ControllerBase
    {
        public Sharepoint sharepoint = Sharepoint.sharepoint;
        public DataMessage message = Sharepoint.sharepoint.message;

        public void Result(object sender)
        {
            this.sharepoint.server.Send(message: JsonConvert.SerializeObject(sender), kick: true);
        }
    }
}