using System;

namespace ApiGateway.Entities
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public string Description { get; set; }
        public DateTime? DateContacted { get; set; }
        public int AddedFrom { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
