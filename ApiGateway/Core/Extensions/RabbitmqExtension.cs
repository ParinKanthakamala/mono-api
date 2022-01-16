using System;
using System.Threading.Tasks;
using Gateway;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApiGateway.Core.Extensions
{
    public static class RabbitmqExtension
    {
        public static string Send(this ControllerBase source, DataMessage sender)
        {
            Console.WriteLine("RPC Client");
            var t = InvokeAsync(sender);
            t.Wait();
            Console.WriteLine(t.Result);
            // return JsonConvert.DeserializeObject<DataMessage>(t.Result);
            return t.Result;
        }

        private static async Task<string> InvokeAsync(DataMessage message)
        {
            // var rnd = new Random(Guid.NewGuid().GetHashCode());
            var rpcClient = new RpcClient(host: "localhost");
            Console.WriteLine("send to service");

            try
            {
                var response = rpcClient.CallAsync(message);
                Console.WriteLine(JsonConvert.DeserializeObject(response));
                Console.WriteLine(" [.] Got '{0}'", response);
                rpcClient.Close();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // return default(Task<string>);
            return "";
        }
    }
}