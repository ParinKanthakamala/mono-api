using System;

namespace ApiGateway.Entities
{
    public partial class GdprRequests
    {
        public int GdprRequestId { get; set; }
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public int LeadId { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestFrom { get; set; }
        public string Description { get; set; }
    }
}
