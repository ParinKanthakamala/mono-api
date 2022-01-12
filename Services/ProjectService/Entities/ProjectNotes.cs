namespace ProjectService.Entities
{
    public partial class ProjectNotes
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Content { get; set; }
        public int StaffId { get; set; }
    }
}
