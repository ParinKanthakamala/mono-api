using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public class SharePoint
    {
        public static Dictionary<string, object> GLOBALS = new();

        public static IConfiguration Configuration;

        public static Dictionary<string, string> Cookies = new();
        public static string CustomerHead = "";
        public static string CustomerView = "";
        public static string CustomerFooter = "";
        public static string FCPATH = "";
        public static string VIEWPATH = "";
        public static string APP_CRON_KEY = "";

        public static string PROPOSAL_ATTACHMENTS_FOLDER = "uploads/proposals/";
        public static string ESTIMATE_ATTACHMENTS_FOLDER = "uploads/estimates/";
        public static string CONTRACTS_UPLOADS_FOLDER = "uploads/contracts/";

        public static string UPLOADS_IMAGES_FOLDER = CONTRACTS_UPLOADS_FOLDER + "images/";

        public static string AreaName = "";


        //
        public static string processed_digital_signature = "";


        public static string CONNECTION_ID = "";

        //


        //
        public static string ConnectionString;

        public static string Language = "en";
        public static string Local = "en";
        public static string DateFormat = "Y-m-d H:i:s";
        private static DateTime? _now;
        public static string CRON = null;


        public static IServiceCollection ServiceCollection
        {
            get;
            set;
            // _serviceCollection.AddTransient<IViewRenderingService, ViewRenderingService>(); 
        } = null;

        //
        public static string Location => "https://localhost:5001/";


        public static DateTime Now
        {
            get { return _now ??= DateTime.Now; }
        }
    }
}