using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Comments
    {
        public uint Id { get; set; }
        public int PostId { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorUrl { get; set; }
        public string AuthorIp { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateGmt { get; set; }
        public string Content { get; set; }
        public int Karma { get; set; }
        public string Approved { get; set; }
        public string Agent { get; set; }
        public string Type { get; set; }
        public int Parent { get; set; }
        public int UserId { get; set; }
    }
}
