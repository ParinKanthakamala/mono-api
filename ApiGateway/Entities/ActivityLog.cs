using System;

namespace ApiGateway.Entities
{
    public partial class ActivityLog
    {
        public int ActivityLogId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}
