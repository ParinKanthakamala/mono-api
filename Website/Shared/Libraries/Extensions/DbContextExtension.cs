using Shared.Common;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Libraries.Extensions
{
    public static class DbContextExtension
    {
        public static void CreateConnection(this MyContext source, ref DbContextOptionsBuilder optionsBuilder)
        {
            var appsettings = source.appsettings();
            if (appsettings.Driver.ToLower() == "mysql")
                optionsBuilder.UseMySql(
                    "server=localhost;user=root;password=password;database=docyg_dev;convert zero datetime=True;treattinyasboolean=True",
                    x => x.ServerVersion("5.7.32-mysql"));
        }
    }
}