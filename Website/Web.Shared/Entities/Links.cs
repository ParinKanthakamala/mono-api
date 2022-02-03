using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Links
    {
        public ulong Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
        public string Visible { get; set; }
        public ulong Owner { get; set; }
        public int Rating { get; set; }
        public DateTime Updated { get; set; }
        public string Rel { get; set; }
        public string Notes { get; set; }
        public string Rss { get; set; }
    }
}
