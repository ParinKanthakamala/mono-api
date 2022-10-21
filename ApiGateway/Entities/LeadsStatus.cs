namespace ApiGateway.Entities
{
    public partial class LeadsStatus
    {
        public int LeadsStatusId { get; set; }
        public string Name { get; set; }
        public int? StatusOrder { get; set; }
        public string Color { get; set; }
        public int IsDefault { get; set; }
    }
}
