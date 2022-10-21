namespace ApiGateway.Entities
{
    public partial class PinnedProjects
    {
        public int PinnedProjectsId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
