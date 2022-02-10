using Microsoft.AspNetCore.Components;

namespace Server.Core
{
    public abstract class MyRazorBase : ComponentBase
    {
        public SharePoint SharePoint = SharePoint.GetInstance();
        protected abstract override void OnInitialized(); // info : start
    }
}