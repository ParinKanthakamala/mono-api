namespace ApiGateway.Entities
{
    public partial class FormQuestions
    {
        public int FormQuestionId { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public string Question { get; set; }
        public bool Required { get; set; }
        public int QuestionOrder { get; set; }
    }
}
