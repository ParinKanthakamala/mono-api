namespace ApiGateway.System
{
    public class Language
    {
        public static Language label()
        {
            return new Language();
        }

        public static string label(string key)
        {
            return "";
        }

        public void load(string defaultLang)
        {
        }
    }
}