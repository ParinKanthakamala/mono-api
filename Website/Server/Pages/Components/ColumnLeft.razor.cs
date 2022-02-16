using Server.Core;

namespace Server.Pages.Components
{
    public class ColumnLeftBase : MyModulePart
    {
        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            Manage("column_left");
        }
    }
}