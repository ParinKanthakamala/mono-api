namespace ApiGateway.Entities
{
    public partial class TaskFollowers
    {
        public int TaskFollowerId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
