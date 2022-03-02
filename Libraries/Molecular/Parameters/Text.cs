using System.Text.RegularExpressions;
using Molecular.Arguments;

namespace Molecular.Parameters
{
    public class Text : IArgument
    {
        public Text(string value)
        {
            Value = value;
            Original = value;
        }

        public string Original { get; }
        public string Value { get; }

        public virtual bool Match(string value)
        {
            return string.Compare(Value, value, true) == 0;
        }

        public bool MatchAssignment(string name)
        {
            var parts = Value.Split('=');
            return string.Compare(parts[0], name, true) == 0;
        }

        public bool TryGetAssignment(string name, out Assignment assignment)
        {
            var parts = Value.Split('=');
            var match = string.Compare(parts[0], name, true) == 0;

            assignment = match
                ? new Assignment(parts[0], parts[1])
                : Assignment.NotProvided;

            return match;
        }

        public bool IsLiteral()
        {
            return Regex.IsMatch(Value, @"^[a-zA-Z]+$");
        }

        public static implicit operator string(Text literal)
        {
            return literal.Value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}