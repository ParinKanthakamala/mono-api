using System;

namespace ApiGateway.Entities
{
    public partial class Leads
    {
        public int LeadId { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public int Country { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public int Assigned { get; set; }
        public DateTime DateAdded { get; set; }
        public int FromFormId { get; set; }
        public int Status { get; set; }
        public int Source { get; set; }
        public DateTime? LastContact { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? LastStatusChange { get; set; }
        public int AddedFrom { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? LeadOrder { get; set; }
        public string Phonenumber { get; set; }
        public DateTime? DateConverted { get; set; }
        public bool Lost { get; set; }
        public int Junk { get; set; }
        public int LastLeadStatus { get; set; }
        public bool IsImportedFromEmailIntegration { get; set; }
        public string EmailIntegrationUid { get; set; }
        public bool IsPublic { get; set; }
        public string DefaultLanguage { get; set; }
        public int ClientId { get; set; }
    }
}
