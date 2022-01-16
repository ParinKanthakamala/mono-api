using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Molecular.Attributes;
using Module = Molecular.Attributes.Module;

namespace Molecular.Routing
{
    public class Route
    {
        public Module Module;
        public bool Hidden;
        public bool Default;
        public bool HasCapture;
        public Capture Capture;
        public List<Node> Nodes;
        public Help Help;
        public MethodInfo Method;

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
            string commands = string.Join(" ", Nodes);
            var parameters = Method.ParametersAsText();

            string s = commands;
            if (parameters.Length > 0) s += " " + parameters;
            return s;
        }
    }
}