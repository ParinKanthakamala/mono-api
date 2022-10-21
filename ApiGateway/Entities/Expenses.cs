using System;

namespace ApiGateway.Entities
{
    public partial class Expenses
    {
        public int ExpenseId { get; set; }
        public int Category { get; set; }
        public int Currency { get; set; }
        public decimal Amount { get; set; }
        public int? Tax { get; set; }
        public int Tax2 { get; set; }
        public string ReferenceNo { get; set; }
        public string Note { get; set; }
        public string ExpenseName { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int? Billable { get; set; }
        public int? InvoiceId { get; set; }
        public string PaymentMode { get; set; }
        public DateTime Date { get; set; }
        public string RecurringType { get; set; }
        public int? RepeatEvery { get; set; }
        public int Recurring { get; set; }
        public int Cycles { get; set; }
        public int TotalCycles { get; set; }
        public int CustomRecurring { get; set; }
        public DateTime? LastRecurringDate { get; set; }
        public bool? CreateInvoiceBillable { get; set; }
        public bool SendInvoiceToCustomer { get; set; }
        public int? RecurringFrom { get; set; }
        public DateTime DateAdded { get; set; }
        public int AddedFrom { get; set; }
    }
}
