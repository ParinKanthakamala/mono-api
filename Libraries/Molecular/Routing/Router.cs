using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Utils;
using Binder = Molecular.Binding.Binder;

namespace Molecular.Routing
{
    public class Router
    {
        public Binder Binder;
        private readonly List<Type> Globals;
        public Action<Router, Exception> HandleException;
        public ArgumentParser Parser;
        public IServiceProvider services;
        public RoutingWriter Writer;

        public Router(
            List<Route> routes,
            Binder binder,
            ArgumentParser parser,
            RoutingWriter writer,
            IServiceProvider services,
            IEnumerable<Type> globals = null,
            Action<Router, Exception> exceptionhandler = null)
        {
            Globals = globals?.ToList();
            Routes = routes;
            Binder = binder;
            Parser = parser;
            Writer = writer;
            this.services = services;
            HandleException = exceptionhandler ?? DefaultExceptionHandler.Handle;
        }

        public List<Route> Routes { get; }
        public bool DebugMode { get; set; }

        public RoutingResult Handle(string[] args)
        {
            var arguments = Parser.Parse(args);
            return Handle(arguments);
        }

        public RoutingResult Handle(Parameters.Arguments arguments)
        {
            var result = Bind(arguments);

            if (result.Ok)
                Invoke(result);
            else
                Writer.WriteResult(result);

            return result;
        }

        public void Invoke(RoutingResult result)
        {
            try
            {
                var method = result.Bind.Route.Method;
                var instance = services.CreateInstance(method.DeclaringType, this);
                result.Value = method.Invoke(instance, result.Bind.Parameters);
                Console.WriteLine("Router.Invoke(RoutingResult result)");
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException) e = e.InnerException;
                if (HandleException is object) HandleException(this, e);
                else throw e;
            }
        }

        private Bind CreateCaptureBind(Parameters.Arguments arguments, Candidate candidate)
        {
            var args = arguments.WithoutCapture(candidate.Route.Capture);
            if (Binder.TryCreateBind(candidate.Route, args, out var bind))
                return bind;
            throw new Exception("Capture was invoked, but could not be matched");
        }


        public RoutingResult Bind(Parameters.Arguments arguments)
        {
            Binder.Bind(Globals, arguments);

            if (TryGetCaptureCandidate(arguments, out var candidate))
            {
                var bind = CreateCaptureBind(arguments, candidate);
                return CreateResult(arguments, candidate, bind);
            }

            var candidates = GetCandidates(arguments).ToList();
            var routes = candidates.Matching(RouteMatch.Full, RouteMatch.Default, RouteMatch.Capture);
            var binds = Binder.Bind(routes, arguments).ToList();

            return CreateResult(arguments, candidates, binds);
        }


        public bool TryGetCaptureCandidate(Parameters.Arguments arguments, out Candidate candidate)
        {
            foreach (var route in Routes.Where(r => r.Capture is not null))
                if (route.Capture.Match(arguments))
                {
                    candidate = new Candidate(RouteMatch.Capture, route);
                    return true;
                }

            candidate = null;
            return false;
        }

        private static RoutingResult CreateResult(Parameters.Arguments arguments, Candidate candidate, Bind binding)
        {
            var candidates = new List<Candidate> {candidate};
            var bindings = new List<Bind> {binding};
            return CreateResult(arguments, candidates, bindings);
        }

        private static RoutingResult CreateResult(Parameters.Arguments arguments, List<Candidate> candidates,
            List<Bind> bindings)
        {
            (var partial, var full) = candidates.Tally();
            var binds = bindings.Count;
            var status = RouteMatcher.MapRoutingStatus(binds, partial, full);

            return new RoutingResult(arguments, status, bindings, candidates);
        }

        public IEnumerable<Candidate> GetCandidates(Parameters.Arguments arguments)
        {
            foreach (var route in Routes)
            {
                var match = RouteMatcher.Match(route, arguments);
                if (match == RouteMatch.Not) continue;
                yield return new Candidate(match, route);
            }
        }
    }
}