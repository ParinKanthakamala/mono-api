using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Web.Client.Areas.Admin.Components.LeftPanel.Content
{
    public class MyAppsBase : ComponentBase, IDisposable
    {
        public IJSRuntime JsRuntime;

        public void Dispose()
        {
        }

        protected override void OnInitialized()
        {
        }
    }
}