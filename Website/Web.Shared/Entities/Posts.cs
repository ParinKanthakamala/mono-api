using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Posts
    {
        public uint Id { get; set; }
        public uint Author { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateGmt { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Status { get; set; }
        public string CommentStatus { get; set; }
        public string PingStatus { get; set; }
        public string PostPassword { get; set; }
        public string PostName { get; set; }
        public string ToPing { get; set; }
        public string Pinged { get; set; }
        public DateTime Modified { get; set; }
        public DateTime ModifiedGmt { get; set; }
        public string ContentFiltered { get; set; }
        public ulong Parent { get; set; }
        public string Guid { get; set; }
        public int MenuOrder { get; set; }
        public string PostType { get; set; }
        public string PostMimeType { get; set; }
        public long CommentCount { get; set; }
    }
}
