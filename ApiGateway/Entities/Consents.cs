using System;

namespace ApiGateway.Entities
{
    public partial class Consents
    {
        public int ConsentId { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public string Ip { get; set; }
        public int ContactId { get; set; }
        public int LeadId { get; set; }
        public string Description { get; set; }
        public string OptInPurposeDescription { get; set; }
        public int PurposeId { get; set; }
        public string StaffName { get; set; }
    }
}
