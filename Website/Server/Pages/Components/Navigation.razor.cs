using System;
using Shared.Core;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Components
{
    public class NavigationBase : MyComponentBase
    {
        public bool logged = false;
        public ElementReference topnav_hide;
        public ElementReference topnav_index;
        [Parameter] public string Page { get; set; }


        public override void OnUpdate()
        {
            
        }

        protected override void OnInitialized()
        {
            // this.topnav_hide.
            // var scroll = window.scrollTop();
            // if (scroll > 90)
            // {
            //     document.getElementById("topnav-hide").style.top = "0";
            //     "#topnav-index".fadeOut()
            // }
            // else if (scroll == = 0)
            // {
            //     document.getElementById("topnav-hide").style.top = "-90px";
            //     "#topnav-index".fadeIn()
            // }
        }
    }
}