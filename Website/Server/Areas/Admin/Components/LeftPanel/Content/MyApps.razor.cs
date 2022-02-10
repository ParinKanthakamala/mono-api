using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Server.Areas.Admin.Components.LeftPanel.Content
{
    public class MyAppsBase : ComponentBase
    {
        public IJSRuntime JsRuntime;


        protected override void OnInitialized()
        {
        }
    }
}