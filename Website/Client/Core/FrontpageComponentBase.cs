using System.Collections.Generic;
using Client.Entities;
using Shared.Core;

namespace Client.Core
{
    public abstract class FrontpageComponentBase : MyComponentBase
    {
        public List<Href> Breadcrumbs = new();
        public List<Category> Categories = new();
        public List<Href> Informations = new();
        public List<Limit> Limits = new();
        public List<Product> Products = new();
        public string ContentTop { get; set; }
        public string ContentBottom { get; set; }
        public string ColumnRight { get; set; }
        public string ColumnLeft { get; set; }
    }
}