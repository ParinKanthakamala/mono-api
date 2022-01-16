using System.Collections.Generic;
using Molecular.Routing;

namespace Molecular.Utils
{
    public class RoutingError
    {
        public string Message;
        public IList<Route> Candidates;
    }

}