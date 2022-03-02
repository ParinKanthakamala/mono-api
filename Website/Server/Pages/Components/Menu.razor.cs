using System.Collections.Generic;
using Server.Entities;
using Shared.Core;

namespace Server.Pages.Components
{
    public class MenuRazorBase : MyComponentBase
    {
        public List<Category> categories = new();


        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
        }
    }
}