using System;

namespace ApiGateway.Entities
{
    public partial class Announcements
    {
        public int AnnouncementId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int ShowToUsers { get; set; }
        public int ShowToStaff { get; set; }
        public int ShowName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
    }
}