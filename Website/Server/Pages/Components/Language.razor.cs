using System;
using System.Collections.Generic;
using Shared.Core;

namespace Server.Pages.Components
{
    public class LanguageRazorBase : MyComponentBase
    {
        public List<Entities.Language> languages = new();


        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            
        }
    }
}