using Web.Shared.Helpers;

namespace Web.Client.Areas.Admin.Core
{
    public abstract class WidgetComponent : AdminComponentBase
    {
        protected Helper helper = new();
    }
}