using System;

namespace ApiGateway.Entities
{
    public partial class ViewsTracking
    {
        public int ViewsTrackingId { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public DateTime Date { get; set; }
        public string ViewIp { get; set; }
    }
}
