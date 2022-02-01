using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class Groups
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Owner { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
