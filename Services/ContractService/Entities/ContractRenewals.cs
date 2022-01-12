using System;

namespace ContractService.Entities
{
    public partial class ContractRenewals
    {
        public int Id { get; set; }
        public int Contractid { get; set; }
        public DateTime OldStartDate { get; set; }
        public DateTime NewStartDate { get; set; }
        public DateTime? OldEndDate { get; set; }
        public DateTime? NewEndDate { get; set; }
        public decimal? OldValue { get; set; }
        public decimal? NewValue { get; set; }
        public DateTime DateRenewed { get; set; }
        public string RenewedBy { get; set; }
        public int RenewedByStaffId { get; set; }
        public int? IsOnOldExpiryNotified { get; set; }
    }
}