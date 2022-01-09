using System;
using ApiGateway.Core.Extensions;
using ApiGateway.Library;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return Make("get", null);
        }

        [HttpPost("{*url}")]
        public IActionResult MakePost(DataMessage data)
        {
            return Make("post", data);
        }

        [HttpDelete("{*url}")]
        public IActionResult MakeDelete(DataMessage data)
        {
            return Make("delete", data);
        }

        [HttpPatch("{*url}")]
        public IActionResult MakePatch(DataMessage data)
        {
            return Make("patch", data);
        }

        [HttpPut("{*url}")]
        public IActionResult MakePut(DataMessage data)
        {
            return Make("put", data);
        }

        [HttpHead("{*url}")]
        public IActionResult MakeHead()
        {
            return Ok();
        }

        [HttpOptions("{*url}")]
        public IActionResult MakeOptions(DataMessage data)
        {
            return Make("options", data);
        }

        private IActionResult Make(string method, DataMessage data = default(DataMessage))
        {
            var sender = new DataMessage();
            try
            {
                sender.User = "";
                sender.Method = (string.IsNullOrEmpty(method)) ? Request.Method : method;
                sender.Message = "";
                sender.From = "api-gateway";
                sender.To = this.GetApiName();
                sender.Route = this.GetRoute();
                sender.Host = Request.Host.ToString();
                sender.Type = "Request"; // request | response | error
                // sender.Body = new { };
                sender.Body = Request.Path.HasValue ? Request.Path.Value : "";
                sender.Query = this.GetQuery();
                sender.Token = "";

                return Content(this.Send(sender));
            }
            catch (Exception ex)
            {
                sender.Message = ex.Message;
            }

            return Content(JsonConvert.SerializeObject(sender));
        }
    }
}