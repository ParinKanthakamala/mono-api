using System;

namespace ApiGateway.Entities
{
    public partial class CreditNotes
    {
        public int CreditNoteId { get; set; }
        public int ClientId { get; set; }
        public string DeletedCustomerName { get; set; }
        public int Number { get; set; }
        public string Prefix { get; set; }
        public int NumberFormat { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Date { get; set; }
        public string AdminNote { get; set; }
        public string Terms { get; set; }
        public string ClientNote { get; set; }
        public int Currency { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }
        public decimal? Adjustment { get; set; }
        public int? AddedFrom { get; set; }
        public int? Status { get; set; }
        public int ProjectId { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountTotal { get; set; }
        public string DiscountType { get; set; }
        public string BillingStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public int? BillingCountry { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingZip { get; set; }
        public int? ShippingCountry { get; set; }
        public bool IncludeShipping { get; set; }
        public bool? ShowShippingOnCreditNote { get; set; }
        public int ShowQuantityAs { get; set; }
        public string ReferenceNo { get; set; }
    }
}
