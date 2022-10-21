using Client.Core;

namespace Client.Areas.Website.Pages.Components
{
    public class ContentTopBase : MyModulePart
    {
        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
            Manage("content_top");
        }
    }
}