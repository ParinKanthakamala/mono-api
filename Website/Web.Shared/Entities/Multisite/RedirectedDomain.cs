using System.ComponentModel.DataAnnotations;

namespace Web.Shared.Entities.Multisite
{
    public class RedirectedDomain : SystemEntity
    {
        [Required] public virtual string Url { get; set; }
        public virtual Site Site { get; set; }
    }
}