using Shared.Entities;

namespace Server.Library
{
    public static class GeneralHelper
    {
        public static bool has_permission(this Users users, string permission, string can = default)
        {
            return false;
        }
    }
}