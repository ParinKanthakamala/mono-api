namespace ApiGateway.Entities
{
    public partial class CustomFieldsValues
    {
        public int Id { get; set; }
        public int RelId { get; set; }
        public int FieldId { get; set; }
        public string FieldTo { get; set; }
        public string Value { get; set; }
    }
}
