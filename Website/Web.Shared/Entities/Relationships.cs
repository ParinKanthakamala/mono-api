using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Relationships
    {
        public uint Id { get; set; }
        public uint Category { get; set; }
        public int Order { get; set; }
    }
}
