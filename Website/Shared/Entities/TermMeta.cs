using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public partial class TermMeta
    {
        public ulong MetaId { get; set; }
        public ulong TermId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
