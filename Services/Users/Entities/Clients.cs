using System;

namespace Users.Entities
{
    public partial class Clients
    {
        public int Userid { get; set; }
        public string Company { get; set; }
        public string Vat { get; set; }
        public string Phonenumber { get; set; }
        public int Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public DateTime Datecreated { get; set; }
        public int Active { get; set; }
        public int? Leadid { get; set; }
        public string BillingStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public int? BillingCountry { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingZip { get; set; }
        public int? ShippingCountry { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string DefaultLanguage { get; set; }
        public int DefaultCurrency { get; set; }
        public int ShowPrimaryContact { get; set; }
        public string StripeId { get; set; }
        public int RegistrationConfirmed { get; set; }
        public int Addedfrom { get; set; }
    }
}
