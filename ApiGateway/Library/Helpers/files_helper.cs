using System.Collections.Generic;
using System.Linq;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class files_helper
    {
        public static string unique_filename(this object source, string dir, string filename)
        {
            return filename;
        }


        public static List<string> get_html5_video_extensions(this object source)
        {
            var extensions = new List<string>()
                {"mp4", "m4v", "webm", "ogv", "ogg", "flv"};
            hooks().ApplyFilters("html5_video_extensions", extensions);
            return extensions;
        }


        public static string get_mime_class(this object source, string mime)
        {
            if (string.IsNullOrEmpty(mime))
            {
                return "mime mime-file";
            }

            var _temp_mime = mime.Split("/");
            var part1 = _temp_mime[0];
            var part2 = _temp_mime[1];
            switch (part1)
            {
                case "image" when !part2.Contains("photoshop"):
                    return "mime mime-photoshop";
                case "image":


                    return "mime mime-image";
                case "audio":
                    return "mime mime-audio";
                case "video":
                    return "mime mime-video";
                case "text":
                    return "mime mime-file";
                case "application" when part2 == "pdf":
                    return "mime mime-pdf";
                case "application" when part2 == "illustrator":
                    return "mime mime-illustrator";
                case "application" when part2 == "zip" || part2 == "gzip" || part2.Contains("tar") ||
                                        part2.Contains("compressed"):
                    return "mime mime-zip";
                case "application"
                    when part2.Contains("powerpoint") || part2.Contains("presentation"):
                    return "mime mime-powerpoint ";
                case "application" when part2.Contains("excel") || part2.Contains("sheet"):
                    return "mime mime-excel";
                case "application" when part2 == "msword" || part2 == "rtf" || part2.Contains("document"):
                    return "mime mime-word";
                default:
                    return "mime mime-file";
            }
        }

        public static string protected_file_url_by_path(this object source, string path, bool preview = false)
        {
            if (preview)
            {
                //var fname = "//";
                //var fext = ".png";
                var thumbPath = "";
                // if (File.Exists(thumbPath))
                // {
                //     return thumbPath.Replace(SharePoint.FCPATH, "");
                // }

                // return path.Replace(SharePoint.FCPATH, "");
            }

            // return path.Replace(SharePoint.FCPATH, "");
            return "";
        }


        public static bool is_image(this object source, string path)
        {
            var possibleBigFiles = new List<string>()
            {
                "pdf", "zip", "mp4", "ai",
                "psd", "ppt", "gzip", "rar",
                "tar", "tgz", "mpeg", "mpg",
                "flv", "mov", "wav", "avi",
            };

            var pathArray = path.Split('.').ToList();
            var ext = pathArray.LastOrDefault();
            if (possibleBigFiles.Contains(ext))
            {
                return false;
            }

            var image = path.Split('/');
            var imageType = image[2];
            return (new List<string>() {"gif", "jpg", "png", "bmp"}).Contains(imageType);
        }
    }
}