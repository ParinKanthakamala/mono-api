namespace Shared.Entities
{
    public class Postmeta
    {
        public ulong MetaId { get; set; }
        public ulong PostId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}