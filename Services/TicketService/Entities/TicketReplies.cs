using System;

namespace TicketService.Entities
{
    public partial class TicketReplies
    {
        public int Id { get; set; }
        public int Ticketid { get; set; }
        public int? Userid { get; set; }
        public int Contactid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int? Attachment { get; set; }
        public int? Admin { get; set; }
    }
}
