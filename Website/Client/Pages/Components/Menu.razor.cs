using System.Collections.Generic;
using Client.Entities;
using Shared.Core;

namespace Client.Pages.Components
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