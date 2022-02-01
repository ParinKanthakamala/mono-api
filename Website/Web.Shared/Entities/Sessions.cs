using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Sessions
    {
        public string Id { get; set; }
        public string IpAddress { get; set; }
        public uint Timestamp { get; set; }
        public byte[] Data { get; set; }
    }
}
