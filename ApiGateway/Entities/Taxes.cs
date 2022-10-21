namespace ApiGateway.Entities
{
    public partial class Taxes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
    }
}
