using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Debug
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public DateTime? Created { get; set; }
    }
}
