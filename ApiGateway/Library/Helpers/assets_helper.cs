using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class assets_helper
    {
        public static void init_admin_assets(this object source)
        {
            hooks().DoAction("app_admin_assets");
        }

        public static void add_calendar_assets(this object source, string group = "admin", bool tryGcal = true)
        {
            
        }

        public static string app_compile_css(this object source, string group = "admin")
        {
            return null;
        }

        public static string app_compile_scripts(this object source, string group = "admin")
        {
            return null;
        }
    }
}