using System;

namespace ApiGateway.Entities
{
    public partial class TicketAttachments
    {
        public int TicketAttachmentId { get; set; }
        public int TicketId { get; set; }
        public int? ReplyId { get; set; }
        public string FileName { get; set; }
        public string Filetype { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
