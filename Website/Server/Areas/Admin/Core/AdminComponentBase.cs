using Client.Helpers;
using Client.Library;
using Shared.Core;

namespace Server.Areas.Admin.Core
{
    public abstract class AdminComponentBase : MyComponentBase
    {
        public Helper helper = new();

        public Myself myself = new();
    }
}