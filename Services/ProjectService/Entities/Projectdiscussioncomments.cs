using System;

namespace ProjectService.Entities
{
    public partial class Projectdiscussioncomments
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public string DiscussionType { get; set; }
        public int? Parent { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Content { get; set; }
        public int StaffId { get; set; }
        public int? ContactId { get; set; }
        public string Fullname { get; set; }
        public string FileName { get; set; }
        public string FileMimeType { get; set; }
    }
}
