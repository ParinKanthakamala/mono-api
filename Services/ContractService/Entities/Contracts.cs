using System;

namespace ContractService.Entities
{
    public partial class Contracts
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public int Client { get; set; }
        public DateTime? Datestart { get; set; }
        public DateTime? Dateend { get; set; }
        public int? ContractType { get; set; }
        public int Addedfrom { get; set; }
        public DateTime Dateadded { get; set; }
        public int Isexpirynotified { get; set; }
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