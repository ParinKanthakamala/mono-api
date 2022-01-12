namespace DocumentService.Entities
{
    public partial class FormResults
    {
        public int Resultid { get; set; }
        public int Boxid { get; set; }
        public int? Boxdescriptionid { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public int Questionid { get; set; }
        public string Answer { get; set; }
        public int Resultsetid { get; set; }
    }
}
