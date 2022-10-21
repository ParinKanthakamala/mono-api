namespace ApiGateway.Entities
{
    public partial class Options
    {
        public int OptionId { get; set; }
        public string Section { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public double Autoload { get; set; }
    }
}
