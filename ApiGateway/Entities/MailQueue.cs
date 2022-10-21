using System;

namespace ApiGateway.Entities
{
    public partial class MailQueue
    {
        public int MailQueueId { get; set; }
        public string Engine { get; set; }
        public string Email { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Message { get; set; }
        public string AltMessage { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
        public string Headers { get; set; }
        public string Attachments { get; set; }
    }
}
