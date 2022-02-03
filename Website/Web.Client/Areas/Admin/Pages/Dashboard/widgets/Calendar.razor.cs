using System;
using System.Collections.Generic;
using Web.Client.Areas.Admin.Core;

namespace Web.Client.Areas.Admin.Pages.Dashboard.widgets
{
    public class CalendarRazorBase : WidgetComponent
    {
        public List<dynamic> goals = new();

        public override void OnUpdate()
        {

        }

        protected override void OnInitialized()
        {

        }
    }
}