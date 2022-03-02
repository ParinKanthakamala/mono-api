using System;

namespace Users.Entities
{
    public class Staff
    {
        public int Staffid { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Phonenumber { get; set; }
        public string Skype { get; set; }
        public string Password { get; set; }
        public DateTime Datecreated { get; set; }
        public string ProfileImage { get; set; }
        public string LastIp { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public string NewPassKey { get; set; }
        public DateTime? NewPassKeyRequested { get; set; }
        public int Admin { get; set; }
        public int? Role { get; set; }
        public int Active { get; set; }
        public string DefaultLanguage { get; set; }
        public string Direction { get; set; }
        public string MediaPathSlug { get; set; }
        public int IsNotStaff { get; set; }
        public decimal HourlyRate { get; set; }
        public bool? TwoFactorAuthEnabled { get; set; }
        public string TwoFactorAuthCode { get; set; }
        public DateTime? TwoFactorAuthCodeRequested { get; set; }
        public string EmailSignature { get; set; }
    }
}