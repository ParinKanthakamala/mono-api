using System;

namespace TicketService.Entities
{
    public partial class TicketAttachments
    {
        public int Id { get; set; }
        public int Ticketid { get; set; }
        public int? Replyid { get; set; }
        public string FileName { get; set; }
        public string Filetype { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
