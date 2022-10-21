using System;

namespace ApiGateway.Entities
{
    public partial class UserAutoLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserAgent { get; set; }
        public string LastIp { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Staff { get; set; }
        public string Key { get; set; }
    }
}
