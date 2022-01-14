using System.Collections.Generic;
using Gateway.Routing;

namespace Gateway.Utils
{
    public class RoutingError
    {
        public string Message;
        public IList<Route> Candidates;
    }

}