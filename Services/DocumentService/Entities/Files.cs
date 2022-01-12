using System;

namespace DocumentService.Entities
{
    public partial class Files
    {
        public int Id { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public string FileName { get; set; }
        public string Filetype { get; set; }
        public int VisibleToCustomer { get; set; }
        public string AttachmentKey { get; set; }
        public string External { get; set; }
        public string ExternalLink { get; set; }
        public string ThumbnailLink { get; set; }
        public int Staffid { get; set; }
        public int? ContactId { get; set; }
        public int TaskCommentId { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
