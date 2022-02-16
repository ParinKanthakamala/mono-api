using System.Collections.Generic;
using Shared.Core;
using Server.Entities;

namespace Server.Pages.Components
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