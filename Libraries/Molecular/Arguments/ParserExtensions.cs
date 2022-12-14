using System;

namespace Molecular.Arguments
{
    public static class ParserExtensions
    {
        public static Parameters.Arguments Parse(this ArgumentParser parser, string s)
        {
            var args = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return parser.Parse(args);
        }
    }
}