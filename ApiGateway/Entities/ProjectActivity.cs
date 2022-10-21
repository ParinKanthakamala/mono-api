using System;

namespace ApiGateway.Entities
{
    public partial class ProjectActivity
    {
        public int ProjectActivityId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public string Fullname { get; set; }
        public int VisibleToCustomer { get; set; }
        public string DescriptionKey { get; set; }
        public string AdditionalData { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
