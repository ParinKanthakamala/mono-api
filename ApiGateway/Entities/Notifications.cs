using System;

namespace ApiGateway.Entities
{
    public partial class Notifications
    {
        public int NotificationId { get; set; }
        public int Isread { get; set; }
        public bool IsreadInline { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int FromUserId { get; set; }
        public int FromClientId { get; set; }
        public string FromFullname { get; set; }
        public int ToUserId { get; set; }
        public int? FromCompany { get; set; }
        public string Link { get; set; }
        public string AdditionalData { get; set; }
    }
}
