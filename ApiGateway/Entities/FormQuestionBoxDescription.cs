namespace ApiGateway.Entities
{
    public partial class FormQuestionBoxDescription
    {
        public int QuestionBoxDescriptionId { get; set; }
        public string Description { get; set; }
        public string BoxId { get; set; }
        public int QuestionId { get; set; }
    }
}
