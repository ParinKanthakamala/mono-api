using System;
using Web.Client.Core.ComponentBases;

namespace Web.Client.Areas.Admin.Layout
{
    public class AdminSidebarLeftBase : MyComponentBase, IDisposable
    {
        public string MyEmail = "admin@localhost.com";
        public string MyName = "John Doe";

        public void Dispose()
        {
        }

        protected override void OnInitialized()
        {
            // MyName = (string) sharepoint["name"];
        }
    }
}