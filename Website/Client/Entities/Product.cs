namespace Client.Entities
{
    public class Product
    {
        public bool special = false;
        public string tax { get; set; }
        public string href { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int rating { get; set; }
        public string description { get; set; }
    }
}