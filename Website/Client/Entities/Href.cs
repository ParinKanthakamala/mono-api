namespace Client.Entities
{
    public class Href
    {
        public Href(string href, string title)
        {
            this.href = href;
            this.title = title;
        }

        public string href { get; set; }
        public string title { get; set; }

        public static Href Create(string href, string text)
        {
            return new(href, text);
        }
    }
}