using System;

namespace ApiGateway.Entities
{
    public partial class InvoicePaymentRecords
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateRecorded { get; set; }
        public string Note { get; set; }
        public string TransactionId { get; set; }
    }
}
