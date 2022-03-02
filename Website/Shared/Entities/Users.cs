using System;

namespace Shared.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nicename { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string ActivationKey { get; set; }
        public int Status { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}