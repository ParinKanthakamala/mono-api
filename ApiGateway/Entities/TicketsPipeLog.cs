using System;

namespace ApiGateway.Entities
{
    public partial class TicketsPipeLog
    {
        public int TicketsPipeLogId { get; set; }
        public DateTime Date { get; set; }
        public string EmailTo { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
