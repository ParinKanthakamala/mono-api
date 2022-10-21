using System;

namespace ApiGateway.Entities
{
    public partial class CreditNoteRefunds
    {
        public int CreditNoteRefundId { get; set; }
        public int CreditNoteId { get; set; }
        public int UserId { get; set; }
        public DateTime RefundedOn { get; set; }
        public string PaymentMode { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
