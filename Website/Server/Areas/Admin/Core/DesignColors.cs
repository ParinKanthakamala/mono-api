namespace Server.Areas.Admin.Core
{
    public class Colors
    {
        public Colors(string name, string code)
        {
            Name = name.ToUpper();
            Code = code;
            ClassName = "bg-" + name.Replace(" ", "-").ToLower();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string ClassName { get; set; }
    }


    public class DesignColors
    {
        public Colors AMBER = new("amber", "#FFC107");
        public Colors BLUE = new("blue", "#2196f3");
        public Colors BLUE_GRAY = new("blue gray", "#607d8b");
        public Colors BROWN = new("brown", "#795548");
        public Colors CYAN = new("cyan", "#00bcd4");
        public Colors DEEP_ORANGE = new("deep orange", "#ff5722");
        public Colors DEEP_PURPLE = new("deep purple", "#6734b7");
        public Colors GRAY = new("gray", "#9e9e9e");
        public Colors GREEN = new("green", "#4caf50");
        public Colors INDIGO = new("indigo", "#3f51b5");
        public Colors LIGHT_BLUE = new("light blue", "#03a9f4");
        public Colors LIGHT_GREEN = new("red", "#f44336");
        public Colors LIME = new("lime", "#cddc39");
        public Colors ORANGE = new("orange", "#FF9800");
        public Colors PINK = new("pink", "#e91e63");
        public Colors PURPLE = new("purple", "#9c27b0");
        public Colors TEAL = new("teal", "#009688");
    }
}