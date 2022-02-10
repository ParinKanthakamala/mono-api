using System.Collections.Generic;

namespace Server.Entities
{
    public class Category
    {
        public List<Category> children = new();

        public Category(string href, string name)
        {
            this.href = href;
            this.name = name;
        }

        public string href { get; set; }
        public string name { get; set; }

        public static Category Create(string href, string name)
        {
            return new(href, name);
        }
    }
}