using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiGateway.Core
{
    public class MyControllerBase : ControllerBase
    {
        // protected MyContext db = new();
        protected ApiResponse output = new();


        public object JsonObject(object input)
        {
            return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(input));
        }
    }
}