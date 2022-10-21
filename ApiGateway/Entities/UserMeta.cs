namespace ApiGateway.Entities
{
    public partial class UserMeta
    {
        public uint MetaId { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}