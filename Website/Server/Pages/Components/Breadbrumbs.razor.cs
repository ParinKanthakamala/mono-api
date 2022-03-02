using System.Collections.Generic;
using Server.Entities;
using Shared.Core;

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