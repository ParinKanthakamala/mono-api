using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using static ApiGateway.System.Url;

namespace ApiGateway.Library.Helpers.Staff
{
    public class staff_profile_image : ViewComponent
    {
        public HtmlString Invoke(int id, string classes = "staff-profile-image",
            string type = "small", IEnumerable<string> imgAttrs = default(List<string>))
        {
            var output = string.Empty;
            var url = base_url("assets/images/user-placeholder.jpg");

            foreach (var kvp in imgAttrs)
            {
            }


            return new HtmlString(output);
        }
    }
}