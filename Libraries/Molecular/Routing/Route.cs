using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Molecular.Attributes;
using Module = Molecular.Attributes.Module;

namespace Molecular.Routing
{
    public class Route
    {
        public Capture Capture;
        public bool Default;
        public bool HasCapture;
        public Help Help;
        public bool Hidden;
        public MethodInfo Method;
        public Module Module;
        public List<Node> Nodes;

        public Route(Module module, IEnumerable<Node> nodes, MethodInfo method, Help help, bool hidden, Capture capture,
            bool isdefault)
        {
            Module = module;
            Nodes = nodes.ToList();
            Method = method;
            Help = help;
            Capture = capture;
            HasCapture = capture is not null;
            Hidden = hidden | HasCapture;
            Default = isdefault;
        }

        public string Description => Help?.Description;

        public override string ToString()
        {
            var commands = string.Join(" ", Nodes);
            var parameters = Method.ParametersAsText();

            var s = commands;
            if (parameters.Length > 0) s += " " + parameters;
            return s;
        }
    }
}