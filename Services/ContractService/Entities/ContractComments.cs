using System;

namespace ContractService.Entities
{
    public partial class ContractComments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ContractId { get; set; }
        public int Staffid { get; set; }
        public DateTime Dateadded { get; set; }
    }
}