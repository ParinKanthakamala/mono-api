using System;

namespace ApiGateway.Entities
{
    public partial class TrackedMails
    {
        public int TrackedMailId { get; set; }
        public string Uid { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public bool Opened { get; set; }
        public DateTime? DateOpened { get; set; }
        public string Subject { get; set; }
    }
}
