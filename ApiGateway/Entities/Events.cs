using System;

namespace ApiGateway.Entities
{
    public partial class Events
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Public { get; set; }
        public string Color { get; set; }
        public bool IsStartNotified { get; set; }
        public int ReminderBefore { get; set; }
        public string ReminderBeforeType { get; set; }
    }
}
