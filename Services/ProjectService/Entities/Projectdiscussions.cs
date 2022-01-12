using System;

namespace ProjectService.Entities
{
    public partial class Projectdiscussions
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool ShowToCustomer { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime? LastActivity { get; set; }
        public int StaffId { get; set; }
        public int ContactId { get; set; }
    }
}
