using Server.Helpers;

namespace Server.Areas.Admin.Core
{
    public abstract class WidgetComponent : AdminComponentBase
    {
        protected Helper helper = new();
    }
}