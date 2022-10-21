namespace ApiGateway.Entities
{
    public partial class UserPermissions
    {
        public int UserId { get; set; }
        public string Feature { get; set; }
        public string Capability { get; set; }
    }
}
