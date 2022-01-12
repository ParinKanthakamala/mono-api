using System;

namespace ProjectService.Entities
{
    public partial class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Clientid { get; set; }
        public int BillingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime ProjectCreated { get; set; }
        public DateTime? DateFinished { get; set; }
        public int? Progress { get; set; }
        public int ProgressFromTasks { get; set; }
        public decimal? ProjectCost { get; set; }
        public decimal? ProjectRatePerHour { get; set; }
        public decimal? EstimatedHours { get; set; }
        public int Addedfrom { get; set; }
    }
}
