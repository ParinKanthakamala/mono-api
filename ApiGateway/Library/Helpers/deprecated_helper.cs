using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class deprecated_helper
    {
        public static void _deprecated_hook(this object source, string hook, string version, string replacement = null,
            string message = null)
        {
            hooks().DoAction("deprecated_hook_run", hook, replacement, version, message);
        }

        public static void _has_deprecated_errors_admin_body_class(this object source)
        {
            if (hooks().HasFilter("admin_body_class", "_add_has_deprecated_errors_admin_body_class"))
            {
                return;
            }
        }
    }
}