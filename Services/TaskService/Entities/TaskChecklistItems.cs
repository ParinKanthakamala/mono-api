using System;

namespace TaskService.Entities
{
    public partial class TaskChecklistItems
    {
        public int Id { get; set; }
        public int Taskid { get; set; }
        public string Description { get; set; }
        public int Finished { get; set; }
        public DateTime Dateadded { get; set; }
        public int Addedfrom { get; set; }
        public int? FinishedFrom { get; set; }
        public int ListOrder { get; set; }
    }
}
