using System;
using System.Collections.Generic;

namespace Molecular.Routing
{
    public static class RouteMatcher
    {
        public static RouteMatch Match(Route route, Parameters.Arguments arguments)
        {
            var index = 0;
            var count = route.Nodes.Count;

            while (index < count)
                if (arguments.TryGetCommand(index, out var value))
                {
                    if (route.Nodes[index].Matches(value))
                        index++;
                    else break;
                }
                else
                {
                    break;
                }

            return MatchType(count, index);
        }

        private static RouteMatch MatchType(int nodeCount, int index)
        {
            if (nodeCount == 0) return RouteMatch.Default;
            if (index == 0) return RouteMatch.Not;
            if (index > 0 && index == nodeCount) return RouteMatch.Full;
            return RouteMatch.Partial;
        }

        public static RoutingStatus MapRoutingStatus(int binds, int partial, int full)
        {
            if (binds == 1) return RoutingStatus.Ok;

            if (binds == 0)
            {
                if (full > 0) return RoutingStatus.InvalidParameters;
                if (partial > 0) return RoutingStatus.PartialCommand;
                //if (def > 0) return RoutingStatus.InvalidDefault;
                return RoutingStatus.UnknownCommand;
            }

            return RoutingStatus.AmbigousParameters;

            throw new Exception("Invalid status");
        }

        public static (int partial, int full) Tally(this IEnumerable<Candidate> candidates)
        {
            var partial = candidates.Count(RouteMatch.Partial);
            var full = candidates.Count(RouteMatch.Full);
            return (partial, full);
        }
    }
}