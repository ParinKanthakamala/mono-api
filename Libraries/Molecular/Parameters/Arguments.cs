using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Molecular.Arguments;

namespace Molecular.Parameters
{
    [DebuggerDisplay("{Text}")]
    public class Arguments : List<IArgument>
    {
        //List<IArgument> arguments = new();
        //public IArgument this[int index] => arguments[index];
        //public int Count => arguments.Count;

        public Arguments(IEnumerable<IArgument> arguments)
        {
            AddRange(arguments);
        }

        public string Text => string.Join(" ", this);

//        public Arguments(IEnumerable<IArgument> arguments)
//        {
////            this.Commands = commands;
//            this.AddRange(arguments);
//        }

        public IList<T> Match<T>(string name) where T : IArgument
        {
            var oftype = this.OfType<T>();
            var matches = oftype.Where(a => a.Match(name)).ToList();
            return matches;
        }

        public IList<T> Match<T>(Parameter parameter) where T : IArgument
        {
            var oftype = this.OfType<T>();
            var matches = oftype.Where(a => a.Match(parameter)).ToList();
            return matches;
        }

        public bool TryGetCommand(int index, out string result)
        {
            if (index < Count)
            {
                result = this[index].Original;
                return true;
            }

            result = null;
            return false;
        }

        public bool TryGet<T>(int index, out T result) where T : IArgument
        {
            if (index < Count && this[index] is T item)
            {
                result = item;
                return true;
            }

            result = default;
            return false;
        }
    }
}