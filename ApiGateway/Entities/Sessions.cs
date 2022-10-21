using System;

namespace ApiGateway.Entities
{
    public partial class Sessions
    {
        public int SessionId { get; set; }
        public string Token { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public string Data { get; set; }
    }
}
