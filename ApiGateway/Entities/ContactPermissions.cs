namespace ApiGateway.Entities
{
    public partial class ContactPermissions
    {
        public int ContactPermissionsId { get; set; }
        public int PermissionId { get; set; }
        public int UserId { get; set; }
    }
}
