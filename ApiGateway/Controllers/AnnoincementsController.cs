using System.Dynamic;
using ApiGateway.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/announcements")]
    public class AnnouncementsController : MyControllerBase
    {
        [HttpGet("/message")]
        public IActionResult test()
        {
            dynamic output = new ExpandoObject();
            output.message = "test messsage";

            return Content(JsonConvert.SerializeObject(output));
        }
    }
}