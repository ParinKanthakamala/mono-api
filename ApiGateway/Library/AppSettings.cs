namespace ApiGateway.Library
{
    public class AppSettings
    {
        static AppSettings()
        {
            Default = new AppSettings();
        }

        protected AppSettings()
        {
        }

        public static AppSettings Default { get; }
    }
}