using System;

namespace ApiGateway.Entities
{
    public partial class Proposals
    {
        public int ProposalId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int AddedFrom { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal? Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountTotal { get; set; }
        public string DiscountType { get; set; }
        public int ShowQuantityAs { get; set; }
        public int Currency { get; set; }
        public DateTime? OpenTill { get; set; }
        public DateTime Date { get; set; }
        public int? RelId { get; set; }
        public string RelType { get; set; }
        public int? Assigned { get; set; }
        public string Hash { get; set; }
        public string ProposalTo { get; set; }
        public int Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? AllowComments { get; set; }
        public int Status { get; set; }
        public int? EstimateId { get; set; }
        public int? InvoiceId { get; set; }
        public DateTime? DateConverted { get; set; }
        public int PipelineOrder { get; set; }
        public int IsExpiryNotified { get; set; }
        public string AcceptanceFirstname { get; set; }
        public string AcceptanceLastname { get; set; }
        public string AcceptanceEmail { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string AcceptanceIp { get; set; }
        public string Signature { get; set; }
    }
}
