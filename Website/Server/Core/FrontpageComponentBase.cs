using System.Collections.Generic;
using Shared.Core;
using Server.Entities;

namespace Server.Core
{
    public abstract class FrontpageComponentBase : MyComponentBase
    {
        public List<Href> Breadcrumbs = new();
        public List<Category> Categories = new();
        public List<Href> Informations = new();
        public List<Limit> Limits = new();
        public List<Product> Products = new();
    }
}