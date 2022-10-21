namespace ApiGateway.Entities
{
    public partial class ArticleGroups
    {
        public int ArticleGroupId { get; set; }
        public string Name { get; set; }
        public string GroupSlug { get; set; }
        public string Description { get; set; }
        public sbyte Active { get; set; }
        public string Color { get; set; }
        public int? GroupOrder { get; set; }
    }
}
