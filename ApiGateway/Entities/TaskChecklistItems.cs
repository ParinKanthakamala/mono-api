using System;

namespace ApiGateway.Entities
{
    public partial class TaskChecklistItems
    {
        public int TaskChecklistItemId { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int Finished { get; set; }
        public DateTime DateAdded { get; set; }
        public int AddedFrom { get; set; }
        public int? FinishedFrom { get; set; }
        public int ListOrder { get; set; }
    }
}
