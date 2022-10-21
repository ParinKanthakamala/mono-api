using System;

namespace ApiGateway.Entities
{
    public partial class Contracts
    {
        public int ContractId { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public int Client { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? ContractType { get; set; }
        public int AddedFrom { get; set; }
        public DateTime DateAdded { get; set; }
        public int IsExpiryNotified { get; set; }
        public decimal? ContractValue { get; set; }
        public bool? Trash { get; set; }
        public bool NotVisibleToClient { get; set; }
        public string Hash { get; set; }
        public bool Signed { get; set; }
        public string Signature { get; set; }
        public string AcceptanceFirstname { get; set; }
        public string AcceptanceLastname { get; set; }
        public string AcceptanceEmail { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string AcceptanceIp { get; set; }
    }
}
