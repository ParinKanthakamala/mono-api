using System.Collections.Generic;
using Client.Entities;
using Shared.Core;

namespace Client.Pages.Components
{
    public class BreadbrumbsRazorBase : MyComponentBase
    {
        public List<Href> breadcrumbs = new();


        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
        }
    }
}