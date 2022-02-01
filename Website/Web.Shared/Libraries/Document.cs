using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace Web.Shared.Libraries
{
    public class Document : ComponentBase, IDisposable
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        [Inject] protected NavigationManager NavigationManager { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                NavigationManager.LocationChanged -= LocationChanged;
        }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += LocationChanged;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;

            await SetTitle(new Uri(NavigationManager.Uri));
        }

        private Task SetTitle(Uri uri)
        {
            var pageName = uri.Segments.Last();
            // await JsRuntime.InvokeVoidAsync("JsFunctions.setDocumentTitle", PageTitleGenerator.Create(pageName));
            return null;
        }

        private async Task SetBodyClass(Uri uri)
        {
            var title = uri.Segments.Last();
            if (title == "/") title = "home";

            await JsRuntime.InvokeVoidAsync("JsFunctions.setBodyClass", $"p-{title}");
        }

        private async void LocationChanged(object sender, LocationChangedEventArgs e)
        {
            await SetTitle(new Uri(e.Location));
            await SetBodyClass(new Uri(e.Location));
        }
    }
}