using System;

namespace UserService.Entities
{
    public partial class Notes
    {
        public int Id { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public string Description { get; set; }
        public DateTime? DateContacted { get; set; }
        public int Addedfrom { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
