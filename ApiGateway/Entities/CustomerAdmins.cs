using System;

namespace ApiGateway.Entities
{
    public partial class CustomerAdmins
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}
