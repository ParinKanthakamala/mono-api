using System;

namespace ApiGateway.Entities
{
    public partial class TicketReplies
    {
        public int TicketReplyId { get; set; }
        public int TicketId { get; set; }
        public int? UserId { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int? Attachment { get; set; }
        public int? Admin { get; set; }
    }
}
