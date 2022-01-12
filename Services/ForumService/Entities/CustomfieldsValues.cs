namespace ForumService.Entities
{
    public partial class CustomfieldsValues
    {
        public int Id { get; set; }
        public int Relid { get; set; }
        public int Fieldid { get; set; }
        public string Fieldto { get; set; }
        public string Value { get; set; }
    }
}
