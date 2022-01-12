using System;

namespace LeadService.Entities
{
    public partial class LeadIntegrationEmails
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Dateadded { get; set; }
        public int Leadid { get; set; }
        public int Emailid { get; set; }
    }
}
