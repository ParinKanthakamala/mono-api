using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Owin.Hosting;

namespace Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var url = "http://localhost:8080/";
                using (WebApp.Start<Startup>(url))
                {
                    Console.WriteLine($"Server running at {url}");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:2803");
                });
    }
}