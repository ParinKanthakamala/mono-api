using System;
using System.Collections.Generic;
using Server.Areas.Admin.Core;

namespace Server.Areas.Admin.Pages.Dashboard.widgets
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