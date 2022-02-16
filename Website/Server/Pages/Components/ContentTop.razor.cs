using Server.Core;

namespace Server.Pages.Components
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