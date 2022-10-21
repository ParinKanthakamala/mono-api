using System;

namespace ApiGateway.Entities
{
    public partial class ProjectDiscussions
    {
        public int ProjectDiscussionId { get; set; }
        public int ProjectId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool ShowToCustomer { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastActivity { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }
    }
}
