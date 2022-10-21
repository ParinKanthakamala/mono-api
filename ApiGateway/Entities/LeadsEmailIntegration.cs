namespace ApiGateway.Entities
{
    public partial class LeadsEmailIntegration
    {
        public int LeadsEmailIntegrationId { get; set; }
        public int Active { get; set; }
        public string Email { get; set; }
        public string ImapServer { get; set; }
        public string Password { get; set; }
        public int CheckEvery { get; set; }
        public int Responsible { get; set; }
        public int LeadSource { get; set; }
        public int LeadStatus { get; set; }
        public string Encryption { get; set; }
        public string Folder { get; set; }
        public string LastRun { get; set; }
        public bool? NotifyLeadImported { get; set; }
        public bool? NotifyLeadContactMoreTimes { get; set; }
        public string NotifyType { get; set; }
        public string NotifyIds { get; set; }
        public int MarkPublic { get; set; }
        public bool? OnlyLoopOnUnseenEmails { get; set; }
        public int DeleteAfterImport { get; set; }
        public int CreateTaskIfCustomer { get; set; }
    }
}
