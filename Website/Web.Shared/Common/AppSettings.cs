using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Web.Shared.Common
{
    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public string Driver { get; set; } = "mysql";
        public string ConnectionStrings { get; set; }
        public string ApiUrl { get; set; }
        public List<string> WorkingDir { get; set; }
    }

    public static class AppSettingsExtension
    {
        private static AppSettings _appSettings;

        private static string GetPath()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var development_file = Directory.GetCurrentDirectory() + "/appsettings.Development.json";
            var appsettings_file = Directory.GetCurrentDirectory() + "/appsettings.json";
            return File.Exists(development_file)
                ? development_file
                : appsettings_file;
        }

        public static AppSettings appsettings(this object source)
        {
            if (_appSettings != null) return _appSettings;
            var jsonstring = File.ReadAllText(GetPath());
            try
            {
                _appSettings = JsonConvert.DeserializeObject<AppSettings>(jsonstring);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            return _appSettings;
        }

        public static AppSettings Update(this AppSettings source)
        {
            var jsonstring = JsonConvert.SerializeObject(source);
            using (var writer = new StreamWriter(GetPath()))
            {
                writer.WriteLine(jsonstring);
            }

            _appSettings = null;
            return source.appsettings();
        }
    }
}