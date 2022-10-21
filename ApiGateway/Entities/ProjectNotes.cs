namespace ApiGateway.Entities
{
    public partial class ProjectNotes
    {
        public int ProjectNoteId { get; set; }
        public int ProjectId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
