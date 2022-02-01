using System;
using System.Collections.Generic;

namespace Web.Shared.Entities
{
    public partial class GroupMembers
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public int Group { get; set; }
        public int User { get; set; }
        public string Status { get; set; }
        public string InviteStatus { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
