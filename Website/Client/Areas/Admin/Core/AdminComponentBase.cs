using System.Dynamic;
using Shared.Core;

namespace Client.Areas.Admin.Core
{
    public abstract class AdminComponentBase : MyComponentBase
    {
        // public Helper helper = new();
        public dynamic myself = new ExpandoObject();
    }
}