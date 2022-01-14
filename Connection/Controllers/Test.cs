using System;
using Gateway.Attributes;
using Gateway.Controllers;

namespace Connection.Controllers
{
    [Module, Command]
    public class Test : ControllerBase
    {
        [Command]
        public void Message(string name)
        {
            // this.sharepoint.server.Send("message form server");
            Console.WriteLine("Hello " + name + " !");
        }

        [Command]
        public void Message()
        {
            Console.WriteLine("Test.Message");
            Result(new
            {
                status_code = 200,
                message = "Hello from server"
            });
        }
    }
}