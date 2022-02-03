using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Metas
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public uint ReferenceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Serialize { get; set; }
    }
}
