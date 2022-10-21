namespace ApiGateway.Entities
{
    public partial class Countries
    {
        public int CountryId { get; set; }
        public string Iso2 { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Iso3 { get; set; }
        public string Code { get; set; }
        public string UnMember { get; set; }
        public string CallingCode { get; set; }
        public string Cctld { get; set; }
    }
}
