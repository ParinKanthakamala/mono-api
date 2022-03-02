using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ApiGateway.Core
{
    public class ApiData
    {
        public ApiData(HttpRequest Request)
        {
            this.Request = Request;
            Segments = Request.Path.Value.Split('/').ToList().Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct().ToList();
        }

        public HttpRequest Request { get; set; }

        public List<string> Segments { get; set; }

        public string Name => Segments.Count > 1 ? Segments[0] : "";

        public string Route
        {
            get
            {
                var segments = Segments;
                segments.RemoveAt(0);
                return string.Join('/', segments);
            }
        }
    }
}