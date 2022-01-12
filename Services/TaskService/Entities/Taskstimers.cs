namespace TaskService.Entities
{
    public partial class Taskstimers
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int StaffId { get; set; }
        public decimal HourlyRate { get; set; }
        public string Note { get; set; }
    }
}
