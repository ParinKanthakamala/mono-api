namespace ApiGateway.Entities
{
    public partial class Currencies
    {
        public int CurrencyId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string DecimalSeparator { get; set; }
        public string ThousandSeparator { get; set; }
        public string Placement { get; set; }
        public bool IsDefault { get; set; }
    }
}
