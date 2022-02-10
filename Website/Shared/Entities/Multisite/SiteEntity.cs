namespace Shared.Entities.Multisite
{
    public abstract class SiteEntity : SystemEntity
    {
        public virtual Site Site { get; set; }
        public virtual string SiteName => Site != null ? Site.DisplayName : null;
    }
}