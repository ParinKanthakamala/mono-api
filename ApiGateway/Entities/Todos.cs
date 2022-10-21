using System;

namespace ApiGateway.Entities
{
    public partial class Todos
    {
        public int TodoId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Finished { get; set; }
        public DateTime? DateFinished { get; set; }
        public int? ItemOrder { get; set; }
    }
}
