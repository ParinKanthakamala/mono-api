using System;
using System.Collections.Generic;
using Client.Core;

namespace Client.Areas.Website.Pages.product
{
    public class ProductCategoryBase : FrontpageComponentBase
    {
        public List<dynamic> categories = new();
        public List<string> sorts = new();
        public string thumb = "";


        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized()
        {
            // this.document.setTitle(this.config("config_title"));
            // this.document.setDescription(this.config("config_meta_description"));
            // this.data["heading_title"] = this.config("config_title");
        }
    }
}