namespace ApiGateway.Entities
{
    public partial class TicketsStatus
    {
        public int TicketStatusId { get; set; }
        public string Name { get; set; }
        public int IsDefault { get; set; }
        public string Statuscolor { get; set; }
        public int? StatusOrder { get; set; }
    }
}
