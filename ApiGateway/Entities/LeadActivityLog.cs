using System;

namespace ApiGateway.Entities
{
    public partial class LeadActivityLog
    {
        public int LeadActivityLogId { get; set; }
        public int LeadId { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public bool CustomActivity { get; set; }
    }
}
