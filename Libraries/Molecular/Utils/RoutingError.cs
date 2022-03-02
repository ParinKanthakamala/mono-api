using System.Collections.Generic;
using Molecular.Routing;

namespace Molecular.Utils
{
    public class RoutingError
    {
        public IList<Route> Candidates;
        public string Message;
    }
}