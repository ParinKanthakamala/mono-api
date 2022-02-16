using System;
using Server.Core;

namespace Server.Pages
{
    public class IndexRazor : FrontpageComponentBase
    {
        public string className { get; set; }


        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized()
        {
            className =
                string.IsNullOrEmpty(ColumnLeft) || string.IsNullOrEmpty(ColumnRight)
                    ? !string.IsNullOrEmpty(ColumnLeft) || !string.IsNullOrEmpty(ColumnRight)
                        ? "col-sm-9"
                        : "col-sm-12"
                    : "col-sm-6";
        }
    }
}