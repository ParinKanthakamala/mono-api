using System;
using System.Dynamic;
using Gateway.Controllers;
using Molecular.Attributes;
using Newtonsoft.Json;

namespace Connection.Controllers
{
    [Module("Test"), Command]
    public class Test : ControllerBase
    {
        [Command]
        public object Message(string name)
        {
            dynamic data = new ExpandoObject();
            try
            {
                data.message = "Hello " + name + " !";
                Console.WriteLine("Examples " + name + " !");
                // this.sharepoint[queueName].Write("read ok");
                // return Json(data);
                return JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "Nothing";
        }

        [Command]
        public void Message()
        {
            Console.WriteLine("Test.Message");
            Result(new
            {
                status_code = 200,
                message = "Examples from server"
            });
        }
    }
}