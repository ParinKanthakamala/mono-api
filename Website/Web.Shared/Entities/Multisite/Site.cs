using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Web.Shared.Attributes;

namespace Web.Shared.Entities.Multisite
{
    public class Site : SystemEntity
    {
        public Site()
        {
            RedirectedDomains = new List<RedirectedDomain>();
        }

        [Required] public virtual string Name { get; set; }

        [DisplayName("Base URL")]
        [Required]
        [RegularExpression(@"^(?i)(?!http).*$", ErrorMessage = "Url should be without HTTP")]
        public virtual string BaseUrl { get; set; }

        public virtual string StagingUrl { get; set; }


        public virtual IList<RedirectedDomain> RedirectedDomains { get; set; }

        public virtual string DisplayName => string.Format("{0} ({1})", Name, BaseUrl);

        public virtual string GetFullDomain => "http://" + BaseUrl;

        public virtual bool IsValidForSite(SiteEntity entity)
        {
            if (entity.GetType().GetCustomAttributes(typeof(AdminUISiteAgnosticAttribute), true).Any())
                return true;
            return entity.Site != null && entity.Site.Id == Id;
        }
    }
}