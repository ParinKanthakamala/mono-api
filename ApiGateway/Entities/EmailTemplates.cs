namespace ApiGateway.Entities
{
    public partial class EmailTemplates
    {
        public int EmaiLtemplateId { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public int Plaintext { get; set; }
        public int Active { get; set; }
        public int Order { get; set; }
    }
}
