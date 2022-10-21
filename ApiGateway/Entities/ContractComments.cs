using System;

namespace ApiGateway.Entities
{
    public partial class ContractComments
    {
        public int ContractCommentId { get; set; }
        public string Content { get; set; }
        public int ContractId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
