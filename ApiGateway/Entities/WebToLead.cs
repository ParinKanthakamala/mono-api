using System;

namespace ApiGateway.Entities
{
    public partial class WebToLead
    {
        public int WebToLeadId { get; set; }
        public string FormKey { get; set; }
        public int LeadSource { get; set; }
        public int LeadStatus { get; set; }
        public int NotifyLeadImported { get; set; }
        public string NotifyType { get; set; }
        public string NotifyIds { get; set; }
        public int Responsible { get; set; }
        public string Name { get; set; }
        public string FormData { get; set; }
        public int Recaptcha { get; set; }
        public string SubmitBtnName { get; set; }
        public string SuccessSubmitMsg { get; set; }
        public string Language { get; set; }
        public int AllowDuplicate { get; set; }
        public int MarkPublic { get; set; }
        public string TrackDuplicateField { get; set; }
        public string TrackDuplicateFieldAnd { get; set; }
        public int CreateTaskOnDuplicate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
