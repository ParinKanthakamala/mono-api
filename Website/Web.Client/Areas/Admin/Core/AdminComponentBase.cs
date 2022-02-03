using Web.Client.Core;
using Web.Shared.Core;
using Web.Shared.Helpers;
using Web.Shared.Libraries;

namespace Web.Client.Areas.Admin.Core
{
    public abstract class AdminComponentBase : MyComponentBase
    {
        public Helper helper = new();

        public Myself myself = new();
    }
}