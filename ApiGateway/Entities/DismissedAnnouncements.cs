namespace ApiGateway.Entities
{
    public partial class DismissedAnnouncements
    {
        public int DismissedAnnouncementId { get; set; }
        public int AnnouncementId { get; set; }
        public int Staff { get; set; }
        public int UserId { get; set; }
    }
}
