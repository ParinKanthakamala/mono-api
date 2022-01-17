using System.Collections.Generic;
using System.Diagnostics;

namespace Molecular.Parameters
{
    [DebuggerDisplay("{Text}")]
    public class Parameters : List<Parameter>
    {
        public Parameters(IEnumerable<Parameter> parameters)
        {
            this.AddRange(parameters);
        }

        public  string Text => $"({string.Join(", ", this)})";

    }


}