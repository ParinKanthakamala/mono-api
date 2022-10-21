namespace ApiGateway.Entities
{
    public partial class ProjectMembers
    {
        public int ProjectMembersId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
