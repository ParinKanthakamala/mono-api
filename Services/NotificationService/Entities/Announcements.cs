using System;

namespace NotificationService.Entities
{
    public partial class Announcements
    {
        public int Announcementid { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int Showtousers { get; set; }
        public int Showtostaff { get; set; }
        public int Showname { get; set; }
        public DateTime Dateadded { get; set; }
        public string Userid { get; set; }
    }
}
