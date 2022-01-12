namespace ForumService.Entities
{
    public partial class KnowledgeBaseGroups
    {
        public int Groupid { get; set; }
        public string Name { get; set; }
        public string GroupSlug { get; set; }
        public string Description { get; set; }
        public sbyte Active { get; set; }
        public string Color { get; set; }
        public int? GroupOrder { get; set; }
    }
}
