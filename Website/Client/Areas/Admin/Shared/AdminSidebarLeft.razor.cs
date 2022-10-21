using System.Collections.Generic;
using Shared.Core;

namespace Client.Areas.Admin.Shared
{
    public class SidebarMenuGroup
    {
        public string Title { get; set; }
        public int FloatNumber { get; set; }
        public List<SidebarMenu> Childs { get; set; }
    }

    public class SidebarMenu
    {
        public int FloatNumber { get; set; }
        public string Title { get; set; }
    }

    public class AdminSidebarLeftBase : MyComponentBase
    {
        public List<SidebarMenuGroup> Groups = new();
        public string MyEmail = "admin@localhost.com";
        public string MyName = "John Doe";

        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
            // MyName = (string) sharepoint["name"];

            // SidebarMenuGroup item = new();
            // item.Title = "Header";
            // item.FloatNumber = 3;
            // SidebarMenu child = new();
            // child.Title = "menu";
            // item.Childs.Add(child);
            // this.Groups.Add(item);
        }
    }
}