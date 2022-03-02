using System.Dynamic;
using Client.Areas.Admin.Core;
using Shared.Models;

namespace Client.Areas.Admin.Components.Utilities
{
    public class SetupMenuRazor : AdminComponentBase
    {
        public dynamic menu_active = new ExpandoObject();
        public dynamic menu_inactive = new ExpandoObject();
        public dynamic submenu = new ExpandoObject();


        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
            menu_active = context.Options.options("setup_menu_active");
            // var   menu_active = JsonConvert.DeserializeObject<Option>(menu_active);
            menu_inactive = context.Options.options("setup_menu_inactive");
            // var menu_inactive = json_decode(menu_inactive);
        }
    }
}