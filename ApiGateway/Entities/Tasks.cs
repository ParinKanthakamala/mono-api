using System;

namespace ApiGateway.Entities
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int AddedFrom { get; set; }
        public bool IsAddedFromContact { get; set; }
        public int Status { get; set; }
        public string RecurringType { get; set; }
        public int? Repeat { get; set; }
        public int Recurring { get; set; }
        public int? IsRecurringFrom { get; set; }
        public int Cycles { get; set; }
        public int TotalCycles { get; set; }
        public bool CustomRecurring { get; set; }
        public DateTime? LastRecurringDate { get; set; }
        public int? RelId { get; set; }
        public string RelType { get; set; }
        public bool IsPublic { get; set; }
        public bool Billable { get; set; }
        public bool Billed { get; set; }
        public int InvoiceId { get; set; }
        public decimal HourlyRate { get; set; }
        public int? Milestone { get; set; }
        public int KanbanOrder { get; set; }
        public int MilestoneOrder { get; set; }
        public bool VisibleToClient { get; set; }
        public int DeadlineNotified { get; set; }
    }
}
