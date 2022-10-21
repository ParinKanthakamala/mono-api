using System;

namespace ApiGateway.Entities
{
    public partial class TaskComments
    {
        public int TaskCommentId { get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public int StaffId { get; set; }
        public int ContactId { get; set; }
        public int FileId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
