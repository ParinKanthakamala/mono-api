namespace NotificationService.Entities
{
    public partial class DismissedAnnouncements
    {
        public int Dismissedannouncementid { get; set; }
        public int Announcementid { get; set; }
        public int Staff { get; set; }
        public int Userid { get; set; }
    }
}
