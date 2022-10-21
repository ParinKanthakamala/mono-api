using System;
using System.Globalization;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Shared.Core;
using Tools.Label;

namespace Client.Areas.Website.Pages
{
    public class PageLayoutBase : MyComponentBase
    {
        [Inject] public ILabel label { get; set; }
        [Inject] public ILocalStorageService storage { get; set; }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            var languageCode = "en-US";
            if (await storage.ContainKeyAsync("language-code"))
                languageCode = await storage.GetItemAsStringAsync("language-code");

            label.SetLanguage(CultureInfo.GetCultureInfo(languageCode));
        }
    }
}