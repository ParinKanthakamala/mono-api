using System;
using System.Collections.Generic;
using Shared.Core;

namespace Server.Pages.Components
{
    public class CurrencyRazorBase : MyComponentBase
    {
        public List<Currency> currencies = new();
        public string code { get; set; }
        public string symbol_left { get; set; }
        public string symbol_right { get; set; }


        public override void OnUpdate()
        { 
        }

        protected override void OnInitialized()
        { 
        }
    }
}