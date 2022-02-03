using Web.Shared.Entities;

namespace Web.Shared.Libraries
{
    public static class MySelfExtension
    {
        private static readonly MyContext context = new();

        public static bool is_admin(this Myself source)
        {
            // return source.Users().is_admin();
            return false;
        }

        public static bool has_permission(this Myself source, string route, string action)
        {
            return true;
        }
    }
}