namespace ProjectService.Entities
{
    public partial class PinnedProjects
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int StaffId { get; set; }
    }
}
