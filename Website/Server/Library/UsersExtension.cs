using Shared.Entities;

namespace Client.Library
{
    public static class GeneralHelper
    {
        public static bool has_permission(this Users users, string permission, string can = default)
        {
            return false;
        }
    }
}