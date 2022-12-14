using System;

namespace ApiGateway.Entities
{
    public partial class Contacts
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public int IsPrimary { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public string NewPassKey { get; set; }
        public DateTime? NewPassKeyRequest { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string EmailVerificationKey { get; set; }
        public DateTime? EmailVerificationSentAt { get; set; }
        public string LastId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public bool? Active { get; set; }
        public string ProfileImage { get; set; }
        public string Direction { get; set; }
        public bool? InvoiceEmails { get; set; }
        public bool? EstimateEmails { get; set; }
        public bool? CreditNoteEmails { get; set; }
        public bool? ContractEmails { get; set; }
        public bool? TaskEmails { get; set; }
        public bool? ProjectEmails { get; set; }
        public bool? TicketEmails { get; set; }
    }
}
