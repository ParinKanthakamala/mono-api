using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public partial class TermRelationships
    {
        public ulong ObjectId { get; set; }
        public ulong TermTaxonomyId { get; set; }
        public int TermOrder { get; set; }
    }
}
