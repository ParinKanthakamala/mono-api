namespace UserService.Entities
{
    public partial class UserMeta
    {
        public ulong UmetaId { get; set; }
        public ulong StaffId { get; set; }
        public ulong ClientId { get; set; }
        public ulong ContactId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
