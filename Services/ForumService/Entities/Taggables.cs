namespace ForumService.Entities
{
    public partial class Taggables
    {
        public int RelId { get; set; }
        public string RelType { get; set; }
        public int TagId { get; set; }
        public int TagOrder { get; set; }
    }
}
