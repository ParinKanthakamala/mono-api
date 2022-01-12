using System;

namespace UserService.Entities
{
    public partial class ActivityLog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Staffid { get; set; }
    }
}
