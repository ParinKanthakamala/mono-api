using System;

namespace MarketingService.Entities
{
    public partial class UserAutoLogin
    {
        public string KeyId { get; set; }
        public int UserId { get; set; }
        public string UserAgent { get; set; }
        public string LastIp { get; set; }
        public DateTime LastLogin { get; set; }
        public int Staff { get; set; }
    }
}
