using System;
using System.Collections.Generic;

namespace Website.Core.Entities
{
    public partial class CustomerGroups
    {
        public int Id { get; set; }
        public int Groupid { get; set; }
        public int CustomerId { get; set; }
    }
}
