using System.Collections.Generic;
using Client.Areas.Admin.Core;

namespace Client.Areas.Admin.Pages.Dashboard.widgets
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