namespace ApiGateway.Entities
{
    public partial class Modules
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string InstalledVersion { get; set; }
        public bool Active { get; set; }
    }
}
