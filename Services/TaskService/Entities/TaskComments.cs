using System;

namespace TaskService.Entities
{
    public partial class TaskComments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Taskid { get; set; }
        public int Staffid { get; set; }
        public int ContactId { get; set; }
        public int FileId { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
