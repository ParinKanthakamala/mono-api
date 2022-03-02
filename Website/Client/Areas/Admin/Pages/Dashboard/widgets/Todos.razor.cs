using System.Collections.Generic;
using Client.Areas.Admin.Core;

namespace Client.Areas.Admin.Pages.Dashboard.widgets
{
    public class TodosRazor : AdminComponentBase
    {
        public List<dynamic> todos = new();
        public List<dynamic> todos_finished = new();

        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
        }
    }
}