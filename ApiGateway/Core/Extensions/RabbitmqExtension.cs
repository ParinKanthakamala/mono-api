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


            try
            {
                var promise = new TaskCompletionSource<string>();
                if (promise.Task.Wait(3000))
                {
                    var myResult = promise.Task.Result;
                }

                var response = rpcClient.CallAsync(message);

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