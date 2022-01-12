namespace DocumentService.Entities
{
    public partial class EmailTemplates
    {
        public int Emailtemplateid { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Fromname { get; set; }
        public string Fromemail { get; set; }
        public int Plaintext { get; set; }
        public sbyte Active { get; set; }
        public int Order { get; set; }
    }
}
