using Client.Core;

namespace Client.Areas.Website.Pages.Components
{
    public class ContentBottomBase : MyModulePart
    {
        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
            Manage("content_bottom");
        }
    }
}