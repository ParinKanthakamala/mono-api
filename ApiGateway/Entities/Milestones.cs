using System;

namespace ApiGateway.Entities
{
    public partial class Milestones
    {
        public int MilestoneId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? DescriptionVisibleToCustomer { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
        public string Color { get; set; }
        public int MilestoneOrder { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
