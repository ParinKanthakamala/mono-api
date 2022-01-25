using System;
using System.Dynamic;
using Gateway.Controllers;
using Molecular.Attributes;

namespace Prototype.Controllers
{
    [Module("Test"), Command]
    public class Test : MyControllerBase
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
                return Result(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "Nothing";
        }

        [Command]
        public object Message()
        {
            Console.WriteLine("Test.Message");
            return Result(new
            {
                status_code = 200,
                message = "Examples from server"
            });
        }
    }
}