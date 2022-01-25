using System;
using System.Threading.Tasks;
using Gateway;
using Gateway.Libraries.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Gateway.Libraries.RabbitMQ.RpcClient;

namespace ApiGateway.Core.Extensions
{
    public static class RabbitmqExtension
    {
        public static string Send(this ControllerBase source, string sender)
        {
            var t = InvokeAsync(sender);
            t.Wait();
            Console.WriteLine(t.Result);
            // return JsonConvert.DeserializeObject<DataMessage>(t.Result);
            return t.Result;
        }

        private static async Task<string> InvokeAsync(string message)
        {
            try
            {
                var promise = new TaskCompletionSource<string>();
                if (promise.Task.Wait(3000))
                {
                    var myResult = promise.Task.Result;
                }

                var response = rpc_client.CallAsync(message);
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