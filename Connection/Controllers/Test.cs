using System;
using Gateway.Controllers;
using Molecular.Attributes;

namespace Connection.Controllers
{
    [Module, Command]
    public class Test : ControllerBase
    {
        [Command]
        public void Message(string name)
        {
            Console.WriteLine("Examples " + name + " !");
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