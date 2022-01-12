namespace DocumentService.Entities
{
    public partial class FormQuestions
    {
        public int Questionid { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public string Question { get; set; }
        public bool Required { get; set; }
        public int QuestionOrder { get; set; }
    }
}
