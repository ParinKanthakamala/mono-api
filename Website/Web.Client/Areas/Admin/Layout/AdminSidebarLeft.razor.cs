using System;
using Web.Client.Core;
using Web.Shared.Core;

namespace Web.Client.Areas.Admin.Layout
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