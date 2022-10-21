using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using static ApiGateway.System.Url;

namespace ApiGateway.Library.Helpers
{
    public static class template_helper
    {
        public static string app_js_alerts(this IHtmlHelper source)
        {
            var builder = new StringBuilder();
            var alertclass = source.get_alert_class();
            if (session().HasUserdata("system-popup"))
            {
                builder.Append("<script>");
                builder.Append(
                    @"(function(){
                        if (typeof('system_popup') != undefined) {
                            var popupData = { };
                            popupData.message = ' . json_encode(app_happy_text(CI.session.userdata('system - popup'))) . ';
                            system_popup(popupData);
                        }
                    });");
                builder.Append("</script>");
            }

            if (string.IsNullOrEmpty(alertclass))
            {
                return "";
            }

            var alert_message = "";
            builder.Append("<script>");
            builder.Append(@"(function(){");
            builder.Append("alert_float('" + alertclass + "', '" + alert_message + "');");
            builder.Append(")});");
            builder.Append("</script>");
            return builder.ToString();
        }

        public static string get_company_logo(this object source, string uri = "", string href_class = "",
            string type = "")
        {
            var company_logo = source.get_option<string>("company_logo" + (type == "dark" ? "_dark" : ""));
            var company_name = source.get_option<string>("companyname");
            var logoURL = (string.IsNullOrEmpty(uri)) ? base_url() : base_url(uri);
            // logoURL = hooks().ApplyFilters("logo_href", logoURL);
            // var logo = "";
            // if (!string.IsNullOrEmpty(company_logo))
            // {
            //     var img = new HtmlTag("img");
            //     img.Attr("src", base_url("uploads/company/" + company_logo));
            //     img.Attr("class", "img-responsive");
            //     img.Attr("alt", company_name);
            //     var a = new LinkTag(img.ToString(), logoURL);
            //     a.Attr("class", "logo img-responsive" + (!string.IsNullOrEmpty(href_class) ? href_class : ""));
            // }
            // else if (string.IsNullOrEmpty(company_name))
            // {
            //     var a = new LinkTag(company_name, logoURL);
            //     a.Attr("class", href_class);
            //     logo = a.ToString();
            // }

            // return logo;
            return null;
        }
    }
}