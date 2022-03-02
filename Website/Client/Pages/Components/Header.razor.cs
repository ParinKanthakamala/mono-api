using Microsoft.AspNetCore.Components;
using Shared.Core;

namespace Client.Pages.Components
{
    public class WebsiteHeader : MyComponentBase
    {
        [Parameter] public string Page { get; set; }
        public string logo { get; set; }
        public string name { get; set; }
        public string search { get; set; }
        public string cart { get; set; }


        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
        }
    }
}