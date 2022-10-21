namespace ApiGateway.Entities
{
    public partial class CustomFields
    {
        public int CustomFieldId { get; set; }
        public string FieldTo { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        public string Options { get; set; }
        public bool DisplayInline { get; set; }
        public int? FieldOrder { get; set; }
        public int Active { get; set; }
        public int ShowOnPdf { get; set; }
        public bool ShowOnTicketForm { get; set; }
        public bool OnlyAdmin { get; set; }
        public bool ShowOnTable { get; set; }
        public int ShowOnClientPortal { get; set; }
        public int DisalowClientToEdit { get; set; }
        public int BsColumn { get; set; }
    }
}
