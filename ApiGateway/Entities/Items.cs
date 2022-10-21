namespace ApiGateway.Entities
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public decimal Rate { get; set; }
        public int? Tax { get; set; }
        public int? Tax2 { get; set; }
        public string Unit { get; set; }
        public int GroupId { get; set; }
    }
}
