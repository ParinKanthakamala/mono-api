using System.Collections.Generic;
using System.Linq;

namespace Molecular.Routing
{
    public class Node
    {
        public string[] Names;

        public Node(IEnumerable<string> names)
        {
            Names = names.ToArray();
        }

        public Node(string name)
        {
            Names = new[] {name};
        }

        public bool Matches(string name)
        {
            for (var i = 0; i < Names.Length; i++)
                if (string.Compare(Names[i], name, true) == 0)
                    return true;
            return false;
        }

        public override string ToString()
        {
            return string.Join(" | ", Names);
        }
    }
}