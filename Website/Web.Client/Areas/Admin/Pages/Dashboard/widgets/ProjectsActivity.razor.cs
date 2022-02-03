using System;
using System.Collections.Generic;
using Web.Client.Areas.Admin.Core;

namespace Web.Client.Areas.Admin.Pages.Dashboard.widgets
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