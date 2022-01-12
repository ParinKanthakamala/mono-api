using System;

namespace TicketService.Entities
{
    public partial class Tickets
    {
        public int Ticketid { get; set; }
        public int Adminreplying { get; set; }
        public int Userid { get; set; }
        public int Contactid { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Department { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public int? Service { get; set; }
        public string Ticketkey { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? Admin { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public DateTime? Lastreply { get; set; }
        public int Clientread { get; set; }
        public int Adminread { get; set; }
        public int Assigned { get; set; }
    }
}
