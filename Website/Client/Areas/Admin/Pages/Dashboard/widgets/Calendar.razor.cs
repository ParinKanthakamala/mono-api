using System.Collections.Generic;
using Client.Areas.Admin.Core;

namespace Client.Areas.Admin.Pages.Dashboard.widgets
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