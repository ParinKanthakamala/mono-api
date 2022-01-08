using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiGateway.Core
{
    public class MyModel : ControllerBase
    {
        protected ApiResponse output = new();


        public object JsonObject(object input)
        {
            return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(input));
        }
    }
}