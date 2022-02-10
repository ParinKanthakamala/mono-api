using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Models
{
    public static class QuickExtension
    {
        private static readonly MyContext context = new();
        private static Dictionary<string, Options> option_instance;

        public static Users get_user(this DbSet<Users> users, int id)
        {
            var row = context.Users.FirstOrDefault(table => table.Id == id);
            return row;
        }

        #region OptionsModel

        private static void Initialize()
        {
            if (option_instance != null) return;
            option_instance = new Dictionary<string, Options>();
            context.Options
                .Where(table => table.Autoload == true)
                .ToList()
                .ForEach(options => { option_instance.Add(options.Name, options); });
        }

        public static T option_value<T>(this DbSet<Options> source, string key)
        {
            Initialize();
            var value = source.options(key);
            return (T) Convert.ChangeType(value, typeof(T));
        }


        public static Options options(this DbSet<Options> source, string key)
        {
            Initialize();
            if (option_instance.ContainsKey(key)) return option_instance[key];
            var row = context.Options.FirstOrDefault(table => table.Name == key);
            option_instance.Add(row.Name, row);
            return option_instance[key];
        }

        #endregion
    }
}