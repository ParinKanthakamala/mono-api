using System;

namespace ApiGateway.Entities
{
    public partial class Vault
    {
        public int VaultId { get; set; }
        public int CustomerId { get; set; }
        public string ServerAddress { get; set; }
        public int? Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int Creator { get; set; }
        public string CreatorName { get; set; }
        public bool? Visibility { get; set; }
        public bool ShareInProjects { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string LastUpdatedFrom { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
