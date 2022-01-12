namespace ForumService.Entities
{
    public partial class SpamFilters
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string RelType { get; set; }
        public string Value { get; set; }
    }
}
