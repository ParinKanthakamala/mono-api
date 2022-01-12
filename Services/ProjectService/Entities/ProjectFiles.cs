using System;

namespace ProjectService.Entities
{
    public partial class ProjectFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Filetype { get; set; }
        public DateTime Dateadded { get; set; }
        public DateTime? LastActivity { get; set; }
        public int ProjectId { get; set; }
        public bool? VisibleToCustomer { get; set; }
        public int Staffid { get; set; }
        public int ContactId { get; set; }
        public string External { get; set; }
        public string ExternalLink { get; set; }
        public string ThumbnailLink { get; set; }
    }
}
