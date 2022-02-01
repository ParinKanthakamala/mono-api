using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Options
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Autoload { get; set; }
    }
}
