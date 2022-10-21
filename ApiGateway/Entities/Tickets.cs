using System;

namespace ApiGateway.Entities
{
    public partial class Tickets
    {
        public int TicketId { get; set; }
        public int AdminReplying { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Department { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public int? Service { get; set; }
        public string TicketKey { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? Admin { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public DateTime? LastReply { get; set; }
        public int ClientRead { get; set; }
        public int AdminRead { get; set; }
        public int Assigned { get; set; }
    }
}
