﻿using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public partial class TermTaxonomy
    {
        public ulong TermTaxonomyId { get; set; }
        public ulong TermId { get; set; }
        public string Taxonomy { get; set; }
        public string Description { get; set; }
        public ulong Parent { get; set; }
        public long Count { get; set; }
    }
}