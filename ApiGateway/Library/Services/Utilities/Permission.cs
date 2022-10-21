namespace ApiGateway.Library.Services.Utilities
{
    public class Permission
    {
        public static int Access = 0;
        public static int Modify = 1;
        public static int Delete = 2;
        public static int View = 3;
        public static int ViewOwn = 4;

        public static bool Id(int id, string section, int permission)
        {
            return true;
        }


        public static bool Can(int action, string section)
        {
            return true;
        }

        public static bool Cannot(int action, string section)
        {
            return !Permission.Can(action, section);
        }

        public static bool CanView(string section) => Can(Permission.View, section);

        public static bool CanViewOwn(string section) => Can(Permission.View, section);

        // maxx : can read
        public static bool CanAccess(string section) => Can(Permission.Access, section);

        public static bool CanCreate(string section) => Can(Permission.Access, section);

        // maxx : can modify
        public static bool CanEdit(string section) => Can(Permission.Modify, section);

        // maxx : can delete
        public static bool CanDelete(string section) => Can(Permission.Delete, section);
    }
}