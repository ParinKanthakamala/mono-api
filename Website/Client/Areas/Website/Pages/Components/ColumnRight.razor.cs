using Client.Core;

namespace Client.Areas.Website.Pages.Components
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