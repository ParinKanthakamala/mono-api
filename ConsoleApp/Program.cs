using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(delegate()
            {
                // replace the IP with your system IP Address...
                //Server myserver = new Server("192.168.***.***", 13000);
                var myserver = new Server("127.0.0.1", 13000);
            });
            t.Start();

            Console.WriteLine("Server Started...!");
            Console.WriteLine("Examples World!");
        }
    }
}