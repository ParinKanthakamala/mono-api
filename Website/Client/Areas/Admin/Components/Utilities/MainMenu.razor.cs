using System.Dynamic;
using Client.Areas.Admin.Core;

namespace Client.Areas.Admin.Components.Utilities
{
    public class MainMenuRazor : AdminComponentBase
    {
        public dynamic menu_active = new ExpandoObject();
        public dynamic menu_inactive = new ExpandoObject();

        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            
        }
    }
}