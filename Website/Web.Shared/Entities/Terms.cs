using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Terms
    {
        public uint Id { get; set; }
        public int Group { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
