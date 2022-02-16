using System.Collections.Generic;
using Shared.Core;
using Server.Entities;

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