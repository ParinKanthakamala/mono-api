using System.Collections.Generic;
using Client.Core;
using Client.Entities;
using Shared.Libraries.Extensions;

namespace Client.Areas.Website.Pages.Components
{
    public class FrontpageFooterRazorBase : MyModulePart
    {
        public string account;
        public string affiliate;
        public string contact;
        public List<Href> informations = new();
        public string manufacturer;
        public string newsletter;
        public string order;
        public string powered;
        public string returner;
        public string sitemap;
        public string special;
        public string tracking;
        public string voucher;
        public string wishlist;


        public override void OnUpdate()
        {
        }

        protected override void OnInitialized()
        {
            // model_catalog_information
            //     .getInformations()
            //     .ForEach(row =>
            //     {
            //         if (row.Information.Bottom > 0)
            //             informations.Add(
            //                 Href.Create(
            //                     "#",
            //                     row.InformationDescription.Title
            //                 )
            //             );
            //     });


            contact = this.url("information/contact");
            returner = this.url("account/return/add");
            sitemap = this.url("information/sitemap");
            tracking = this.url("information/tracking");
            manufacturer = this.url("product/manufacturer");
            voucher = this.url("account/voucher");
            affiliate = this.url("affiliate/login");
            special = this.url("product/special");
            account = this.url("account/account");
            order = this.url("account/order");
            wishlist = this.url("account/wishlist");
            newsletter = this.url("account/newsletter");

            // powered = string.Format(language["text_powered"], this.context.Options.options("config_name"), DateTime.Now.ToString("Y"));
            powered = "hello";
            // Whos Online
            // if (this.config<bool>("config_customer_online"))
            // {
            //     var ip = "";
            //     var url = "";
            //     var referer = "";
            //
            //     model_tool_online.addOnline(ip, this.myself().GetId(), url, referer);
            // }

            // data["scripts"] = this.document.getScripts("footer");
        }
    }
}