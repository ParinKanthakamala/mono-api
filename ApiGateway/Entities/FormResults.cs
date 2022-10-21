namespace ApiGateway.Entities
{
    public partial class FormResults
    {
        public int FormResultId { get; set; }
        public int BoxId { get; set; }
        public int? BoxDescriptionId { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public int Resultsetid { get; set; }
    }
}
