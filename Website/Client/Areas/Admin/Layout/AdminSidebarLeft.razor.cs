using Shared.Core;

namespace Client.Areas.Admin.Layout
{
    public class AdminSidebarLeftBase : MyComponentBase
    {
        public string MyEmail = "admin@localhost.com";
        public string MyName = "John Doe";

        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            // MyName = (string) sharepoint["name"];
        }
    }
}