using System;
using System.Collections.Generic;

namespace Website.Core.Entities
{
    public partial class StaffPermissions
    {
        public int StaffId { get; set; }
        public string Feature { get; set; }
        public string Capability { get; set; }
    }
}
