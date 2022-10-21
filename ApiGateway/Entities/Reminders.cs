using System;

namespace ApiGateway.Entities
{
    public partial class Reminders
    {
        public int ReminderId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int IsNotified { get; set; }
        public int RelId { get; set; }
        public int Staff { get; set; }
        public string RelType { get; set; }
        public int NotifyByEmail { get; set; }
        public int Creator { get; set; }
    }
}
