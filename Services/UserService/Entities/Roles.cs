using System;
using System.Collections.Generic;

namespace Website.Core.Entities
{
    public partial class Roles
    {
        public int Roleid { get; set; }
        public string Name { get; set; }
        public string Permissions { get; set; }
    }
}
