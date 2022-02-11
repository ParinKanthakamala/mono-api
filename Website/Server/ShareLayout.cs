namespace Server
{
    public class ShareLayout
    {
        private static ShareLayout instance = null;

        public string ContentTop { get; set; }
        public string ContentBottom { get; set; }
        public string ColumnRight { get; set; }
        public string ColumnLeft { get; set; }


        public static ShareLayout layout
        {
            get { return instance ??= new ShareLayout(); }
        }


        private ShareLayout()
        {
        }
    }
}