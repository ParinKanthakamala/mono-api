using System;

namespace NotificationService.Entities
{
    public partial class Events
    {
        public int Eventid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Userid { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Public { get; set; }
        public string Color { get; set; }
        public bool Isstartnotified { get; set; }
        public int ReminderBefore { get; set; }
        public string ReminderBeforeType { get; set; }
    }
}
