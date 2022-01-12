namespace LeadService.Entities
{
    public partial class LeadsStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Statusorder { get; set; }
        public string Color { get; set; }
        public int Isdefault { get; set; }
    }
}
