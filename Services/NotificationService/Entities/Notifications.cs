using System;

namespace NotificationService.Entities
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public int Isread { get; set; }
        public bool IsreadInline { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Fromuserid { get; set; }
        public int Fromclientid { get; set; }
        public string FromFullname { get; set; }
        public int Touserid { get; set; }
        public int? Fromcompany { get; set; }
        public string Link { get; set; }
        public string AdditionalData { get; set; }
    }
}
