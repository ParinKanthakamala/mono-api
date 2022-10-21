using System;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Core.Extensions;
using Gateway;
using Gateway.Libraries.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/")]
    public class HomeController : MyControllerBase
    {
        [HttpGet("{*url}")]
        public IActionResult MakeGet()
        {
            return Make(Method.GET);
            //return Ok();
        }

        [HttpPost("{*url}")]
        public IActionResult MakePost(DataMessage data)
        {
            return Make(Method.POST, data);
            //return Ok();
        }

        [HttpDelete("{*url}")]
        public IActionResult MakeDelete(DataMessage data)
        {
            return Make(Method.DELETE, data);
            //return Ok();
        }

        [HttpPatch("{*url}")]
        public IActionResult MakePatch(DataMessage data)
        {
            return Make(Method.PATCH, data);
            //return Ok();
        }

        [HttpPut("{*url}")]
        public IActionResult MakePut(DataMessage data)
        {
            return Make(Method.PUT, data);
            //return Ok();
        }

        [HttpHead("{*url}")]
        public IActionResult MakeHead(DataMessage data)
        {
            return Make(Method.HEAD, data);
            //return Ok();
        }

        [HttpOptions("{*url}")]
        public IActionResult MakeOptions(DataMessage data)
        {
            return Make(Method.OPTIONS, data);
            //return Ok();
        }

        private string MakeRoute(string route)
        {
            if (route.Contains("%2F")) route = route.Replace("%2F", "/");

            var output = route.Split('/').ToList();
            output = output.ToArray().Slice(2, output.Count).ToList();
            var temp = string.Join("/", output);
            Console.WriteLine(temp);
            return temp;
        }

        private IActionResult Make(Method method, DataMessage data = default)
        {
            var sender = new DataMessage();
            try
            {
                if (!string.IsNullOrEmpty(Request.Path.Value))
                {
                    var apiData = new ApiData(Request);
                    sender.User = "";
                    sender.Method = method;
                    sender.Message = "";
                    sender.From = AppSettings.RabbitOptions.Name;
                    sender.To = apiData.Name;
                    sender.Route = apiData.Route;
                    sender.Host = Request.Host.ToString();
                    sender.Type = "Request";
                    sender.Body = Request.Path.HasValue ? Request.Path.Value : "";
                    sender.Query = this.GetQuery();
                    sender.Token = "";
                    // Console.WriteLine(JsonConvert.SerializeObject(sender));
                    // var output = rpc_client.CallAsync(JsonConvert.SerializeObject(sender));

                    try
                    {
                        return Content(output.GetType() != typeof(string)
                            ? JsonConvert.SerializeObject(output)
                            : (string) Convert.ChangeType(output, typeof(string)));
                    }
                    catch (Exception ex)
                    {
                        return Content(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                sender.Message = ex.Message;
            }

            return Content(JsonConvert.SerializeObject(sender));
            //return Ok();
        }
    }
}