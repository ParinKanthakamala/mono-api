using System;
using System.Linq;
using ApiGateway.Core.Extensions;
using Gateway;
using Gateway.Libraries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;


namespace ApiGateway.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet("{*url}")]
        public IActionResult MakeGet()
        {
            return Make(Method.Get, null);
        }

        [HttpPost("{*url}")]
        public IActionResult MakePost(DataMessage data)
        {
            return Make(Method.Post, data);
        }

        [HttpDelete("{*url}")]
        public IActionResult MakeDelete(DataMessage data)
        {
            return Make(Method.Delete, data);
        }

        [HttpPatch("{*url}")]
        public IActionResult MakePatch(DataMessage data)
        {
            return Make(Method.Patch, data);
        }

        [HttpPut("{*url}")]
        public IActionResult MakePut(DataMessage data)
        {
            return Make(Method.Put, data);
        }

        [HttpHead("{*url}")]
        public IActionResult MakeHead()
        {
            return Ok();
        }

        [HttpOptions("{*url}")]
        public IActionResult MakeOptions(DataMessage data)
        {
            return Make(Method.Options, data);
        }


        private string MakeRoute(string route)
        {
            if (route.Contains("%2F"))
            {
                route = route.Replace("%2F", "/");
            }

            var output = route.Split('/').ToList();
            output = output.ToArray().Slice(2, output.Count).ToList();
            var temp = string.Join("/", output);
            Console.WriteLine(temp);
            return temp;
        }

        private IActionResult Make(Method method, DataMessage data = default(DataMessage))
        {
            var sender = new DataMessage();
            try
            {
                if (!string.IsNullOrEmpty(Request.Path.Value))
                {
                    sender.User = "";
                    sender.Method = method;
                    sender.Message = "";
                    sender.From = "api-gateway";
                    // sender.To = this.GetApiName();
                    sender.To = "connection";
                    sender.Route = MakeRoute(Request.Path.Value);
                    sender.Host = Request.Host.ToString();
                    sender.Type = "Request"; // request | response | error
                    // sender.Body = new { };
                    sender.Body = Request.Path.HasValue ? Request.Path.Value : "";
                    sender.Query = this.GetQuery();
                    sender.Token = "";

                    var output = this.Send(sender);
                    try
                    {
                        if (output.IsValidJson())
                        {
                            return Content(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(output)));
                        }

                        return Content(output);
                    }
                    catch (Exception ex)
                    {
                        // return Content(ex.Message);
                    }

                    return Content(output);
                }
            }
            catch (Exception ex)
            {
                sender.Message = ex.Message;
            }

            return Content(JsonConvert.SerializeObject(sender));
        }
    }
}