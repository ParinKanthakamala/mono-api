using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Shared.Core;

namespace Client.Core
{
    public abstract class MyModulePart : MyComponentBase
    {
        //

        public List<string> modules = new();
        [Parameter] public string Page { get; set; }
        [Parameter] public string product_id { get; set; }
        [Parameter] public string information_id { get; set; }

        [Parameter] public string path { get; set; }

        protected bool IsVisible { get; set; }

        //
        protected void Manage(string part_name)
        {
            if (string.IsNullOrEmpty(Page))
                Page = "common/hoome";
            var layout_id = 0;

            if (Page == "product/category" && !string.IsNullOrEmpty(this.path))
            {
                var path = this.path.Split('_').ToList();
                // layout_id = model_catalog_category.getCategoryLayoutId(path.Last());
            }
            else if (Page == "product/product" && !string.IsNullOrEmpty(product_id))
            {
                // layout_id = model_catalog_product.getProductLayoutId(product_id);
            }
            else if (Page == "information/information" && string.IsNullOrEmpty(information_id))
            {
                // layout_id = model_catalog_information.getInformationLayoutId(information_id);
            }

            // if (layout_id == 0) layout_id = model_design_layout.getLayout(Page);
            // if (layout_id == 0) layout_id = this.config<int>("config_layout_id");
            try
            {
                // var modules_layout = model_design_layout.getLayoutModules(layout_id, part_name);
                // modules_layout?.ForEach(item =>
                // {
                //     var part = item.Code.Split('.').ToList();
                //     if (part.Count > 0 && this.settings("module_" + part[0] + "_status").Value == "1")
                //         // module_data = this.load.controller("extension/module/".part[0]);
                //         // if (module_data) data["modules"][] = module_data;
                //         modules.Add("extension/module/" + part[0]);
                //     if (part.Count <= 2) return;
                //     var setting_info = model_setting_module.getModule(part[1]);
                //     if (setting_info != null && setting_info.status)
                //         // var output = this.load.controller("extension/module/".part[0], setting_info);
                //         // if (output) data["modules"][] = output;
                //         // this.modules.Add(output);
                //         modules.Add("extension/module/" + part[0] + JsonConvert.SerializeObject(setting_info));
                // });
            }
            catch (Exception ex)
            {
                // db.Debug.Add(new Debug
                // {
                //     Data = ex.Message,
                //     Created = DateTime.Now
                // });
                // db.SaveChanges();
            }
        }
    }
}