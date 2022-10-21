using System;

namespace ApiGateway.Entities
{
    public partial class LeadIntegrationEmails
    {
        public int LeadIntegrationEmailsId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateAdded { get; set; }
        public int LeadId { get; set; }
        public int EmailId { get; set; }
    }
}
