using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Categories
    {
        public uint Id { get; set; }
        public uint Term { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Parent { get; set; }
        public int Count { get; set; }
    }
}
