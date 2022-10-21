using System;

namespace ApiGateway.Entities
{
    public partial class Subscriptions
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DescriptionInItem { get; set; }
        public int ClientId { get; set; }
        public DateTime? Date { get; set; }
        public int Currency { get; set; }
        public int TaxId { get; set; }
        public string StripePlanId { get; set; }
        public string StripeSubscriptionId { get; set; }
        public long? NextBillingCycle { get; set; }
        public DateTime? EndsAt { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public int ProjectId { get; set; }
        public string Hash { get; set; }
        public DateTime Created { get; set; }
        public int CreatedFrom { get; set; }
        public DateTime? DateSubscribed { get; set; }
    }
}
