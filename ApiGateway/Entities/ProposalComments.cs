using System;

namespace ApiGateway.Entities
{
    public partial class ProposalComments
    {
        public int ProposalCommentId { get; set; }
        public string Content { get; set; }
        public int ProposalId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
