using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApiGateway.Library;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiGateway.Core.Extensions
{
    public static class RabbitmqExtension
    {
        public static string Send(this ControllerBase source, DataMessage sender)
        {
            Console.WriteLine("RPC Client");
            var t = InvokeAsync(JsonConvert.SerializeObject(sender));
            t.Wait();
            // return JsonConvert.DeserializeObject<DataMessage>(t.Result);
            return t.Result;
        }

        private static async Task<string> InvokeAsync(string message)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var rpcClient = new RpcClient();
            Console.WriteLine("send to service");
            var response = await rpcClient.CallAsync(message);
            Console.WriteLine(" [.] Got '{0}'", response);
            rpcClient.Close();
            return response;
        }
    }
}