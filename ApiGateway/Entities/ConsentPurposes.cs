using System;

namespace ApiGateway.Entities
{
    public partial class ConsentPurposes
    {
        public int ConsentPurposesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
