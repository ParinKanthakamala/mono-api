using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public partial class Terms
    {
        public ulong TermId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long TermGroup { get; set; }
    }
}
