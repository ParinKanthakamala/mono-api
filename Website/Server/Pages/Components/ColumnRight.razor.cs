using System;
using Server.Core;

namespace Server.Pages.Components
{
    public class ColumnRightBase : MyModulePart
    {
        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            Manage("column_right");
        }
    }
}