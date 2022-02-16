using System.Collections.Generic;
using Server.Areas.Admin.Core;

namespace Server.Areas.Admin.Pages.Dashboard.widgets
{
    public class ProjectsActivityRazor : AdminComponentBase
    {
        public List<ProjectsActivity> projects_activity = new();
        public string href { get; set; }

        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
        }
    }
}