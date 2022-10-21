namespace ApiGateway.Entities
{
    public partial class ProjectSettings
    {
        public int ProjectSettingId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
