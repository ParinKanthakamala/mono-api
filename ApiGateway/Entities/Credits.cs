using System;

namespace ApiGateway.Entities
{
    public partial class Credits
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int CreditId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateApplied { get; set; }
        public decimal Amount { get; set; }
    }
}
