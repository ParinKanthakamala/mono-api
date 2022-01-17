using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ApiGateway.Core
{
    public class ApiData
    {
        public HttpRequest Request { get; set; }

        public List<string> Segments { get; set; }

        public string Name => this.Segments.Count > 1 ? this.Segments[0] : "";

        public string Route
        {
            get
            {
                var segments = this.Segments;
                segments.RemoveAt(0);
                return string.Join('/', segments);
            }
        }

        public ApiData(HttpRequest Request)
        {
            this.Request = Request;
            this.Segments = Request.Path.Value.Split('/').ToList().Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct().ToList();
        }
    }
}