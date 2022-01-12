namespace TaskService.Entities
{
    public partial class TaskAssigned
    {
        public int Id { get; set; }
        public int Staffid { get; set; }
        public int Taskid { get; set; }
        public int AssignedFrom { get; set; }
        public bool IsAssignedFromContact { get; set; }
    }
}
