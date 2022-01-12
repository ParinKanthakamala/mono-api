using System;

namespace ProjectService.Entities
{
    public partial class ProjectActivity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int StaffId { get; set; }
        public int ContactId { get; set; }
        public string Fullname { get; set; }
        public int VisibleToCustomer { get; set; }
        public string DescriptionKey { get; set; }
        public string AdditionalData { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
