namespace Shared.Entities
{
    public class Terms
    {
        public ulong TermId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long TermGroup { get; set; }
    }
}