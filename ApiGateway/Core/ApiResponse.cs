using System;
using System.Dynamic;

namespace ApiGateway.Core
{
    public abstract class ApiToken
    {
        public string Token { get; set; }
        public string Type { get; set; } = "Bearer";
        public int ExpiresIn { get; set; } = 3600;
        public DateTime ExpiresTime { get; set; } = DateTime.Now.AddMinutes(+60);
    }

    public class ApiResponse
    {
        public dynamic Data = new ExpandoObject();
        public string Message { get; set; } = "N/A";
        public DateTime ResponseTime { get; set; } = DateTime.Now;
        public ApiToken TokenData { get; set; }
    }
}