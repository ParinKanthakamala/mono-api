namespace ApiGateway.Entities
{
    public partial class TaskAssigned
    {
        public int TaskAssignedId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int AssignedFrom { get; set; }
        public bool IsAssignedFromContact { get; set; }
    }
}
