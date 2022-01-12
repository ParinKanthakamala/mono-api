using System;

namespace UserService.Entities
{
    public partial class LeadActivityLog
    {
        public int Id { get; set; }
        public int Leadid { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
        public DateTime Date { get; set; }
        public int Staffid { get; set; }
        public string FullName { get; set; }
        public bool CustomActivity { get; set; }
    }
}
