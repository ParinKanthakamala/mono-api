using System;

namespace DocumentService.Entities
{
    public partial class Todos
    {
        public int Todoid { get; set; }
        public string Description { get; set; }
        public int Staffid { get; set; }
        public DateTime Dateadded { get; set; }
        public bool Finished { get; set; }
        public DateTime? Datefinished { get; set; }
        public int? ItemOrder { get; set; }
    }
}
