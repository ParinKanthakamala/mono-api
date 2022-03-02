using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway
{
    public class Example : Controller
    {
        public void LockFile(string lockPath)
        {
            using (var lockFile = new FileStream(
                       lockPath,
                       FileMode.OpenOrCreate,
                       FileAccess.ReadWrite,
                       FileShare.Delete
                   ))

            {
                // 1. Read lock information from file
                // 2. If not locked, write the lock information
            }
        }


        public void RabbitmqUpload()
        {
            // var body = File.ReadAllBytes(@"C:\test.xml");
            //
            // var provider = new MultipartMemoryStreamProvider();
            // await Request.Content.ReadAsMultipartAsync(provider);
            //
            // var file = provider.Contents.FirstOrDefault();
            //
            // var body = await file.ReadAsByteArrayAsync();
            //
            // channel.BasicPublish(
            //     exchange: "",
            //     routingKey: "hello",
            //     basicProperties: null,
            //     body: body);

            // channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
        }
    }
}