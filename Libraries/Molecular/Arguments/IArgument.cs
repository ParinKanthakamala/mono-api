using Molecular.Parameters;

namespace Molecular.Arguments
{
    public interface IArgument
    {
        string Original { get; }
        string Value { get; }
        bool Match(string name);
    }

    public static class ArgumentExtensions
    {
        public static bool Match(this IArgument argument, Parameter parameter)
        {
            return argument.Match(parameter.Name) || argument.Match(parameter.AltName);
        }
    }
}