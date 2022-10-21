namespace ApiGateway.Entities
{
    public partial class ItemTax
    {
        public int ItemTaxId { get; set; }
        public int Itemid { get; set; }
        public int RelId { get; set; }
        public string RelType { get; set; }
        public decimal TaxRate { get; set; }
        public string TaxName { get; set; }
    }
}
