using Gateway.Libraries.Common;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Core
{
    public class MyControllerBase : ControllerBase
    {
        // protected MyContext db = new();
        protected ApiResponse output = new();

        public AppSettings AppSettings
        {
            get
            {
                var item = new object();
                return item.appsettings();
            }
        }

        // public object JsonObject(object input)
        // {
        //     return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(input));
        // }
    }
}