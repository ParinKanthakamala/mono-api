using System.Collections.Generic;
using Molecular.Parameters;

namespace Molecular.Arguments
{
    public class ArgumentParser
    {
        public Parameters.Arguments Parse(string[] args)
        {
            var arguments = ParseArguments(args);
            return new Parameters.Arguments(arguments);
        }

        private static IEnumerable<IArgument> ParseArguments(string[] args)
        {
            foreach (var arg in args)
            {
                foreach (var argument in ParseArgument(arg))
                {
                    yield return argument;
                }
            }
        }

        private static IEnumerable<IArgument> ParseArgument(string arg)
        {
            if (arg.StartsWith("--"))
            {
                yield return new Flag(arg.Substring(2));
            }
            else if (arg.StartsWith("-"))
            {
                foreach (var c in arg.Substring(1))
                {
                    yield return new Flag(c.ToString());
                }
            }
            else
            {
                yield return new Text(arg);
            }
        }
    }
}