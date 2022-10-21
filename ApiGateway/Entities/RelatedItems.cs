namespace ApiGateway.Entities
{
    public partial class RelatedItems
    {
        public int Id { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public int ItemId { get; set; }
    }
}
