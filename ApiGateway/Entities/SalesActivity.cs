using System;

namespace ApiGateway.Entities
{
    public partial class SalesActivity
    {
        public int SalesActivityId { get; set; }
        public string RelType { get; set; }
        public int RelId { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
    }
}
