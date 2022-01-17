using System;
using Molecular.Attributes;

namespace Hello
{
    [Command]
    public class Message
    {
        [Command]
        public void Show()
        {
            Console.WriteLine("Hello from example.");
        }
    }
}