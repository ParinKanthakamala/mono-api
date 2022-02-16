using System.Collections.Generic;
using Server.Areas.Admin.Core;

namespace Server.Areas.Admin.Pages.Dashboard.widgets
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