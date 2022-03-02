using System.Collections.Generic;
using System.Linq;
using Molecular.Binding;

namespace Molecular.Routing
{
    public class RoutingResult
    {
        public Parameters.Arguments Arguments;
        public List<Bind> Binds;
        public List<Candidate> Candidates; //where the commands match, but not necessarily the parameters
        public RoutingStatus Status;

        public RoutingResult(Parameters.Arguments arguments, RoutingStatus status, List<Bind> binds,
            List<Candidate> candidates)
        {
            Arguments = arguments;
            Candidates = candidates;
            Binds = binds;
            Status = status;
        }

        public object? Value { get; set; }

        public bool Ok => Status == RoutingStatus.Ok;

        public Bind Bind => Binds.SingleOrDefault();

        public Route Route => Bind?.Route;

        public int BindCount => Binds.Count;

        public IEnumerable<Route> Routes => Binds.Select(b => b.Route);

        public override string ToString()
        {
            var tally = $"Binds: {BindCount}, Candidates: {Candidates?.Count ?? 0})";
            if (Ok)
                return $"Ok. {tally}";
            return $"Failed. {tally}";
        }
    }
}