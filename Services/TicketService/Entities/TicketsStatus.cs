namespace TicketService.Entities
{
    public partial class TicketsStatus
    {
        public int Ticketstatusid { get; set; }
        public string Name { get; set; }
        public int Isdefault { get; set; }
        public string Statuscolor { get; set; }
        public int? Statusorder { get; set; }
    }
}
