namespace ApiGateway.Entities
{
    public partial class Itemable
    {
        public int ItemableId { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public string Unit { get; set; }
        public int? ItemOrder { get; set; }
    }
}
