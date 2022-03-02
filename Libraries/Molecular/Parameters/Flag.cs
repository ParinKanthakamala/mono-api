using System;
using Molecular.Arguments;

namespace Molecular.Parameters
{
    public class Flag : IArgument
    {
        public Flag(string value)
        {
            Name = value.TrimStart('-');
            IsSet = true;
            Short = value.Length == 1;
        }

        public Flag(string name, bool set)
        {
            Name = name;
            IsSet = set;
            Short = name.Length == 1;
        }

        public bool Short { get; }
        public string Name { get; }

        public bool IsSet { get; }

        [Obsolete("Replaced by IsSet")] public bool Set => IsSet;

        public string Original
        {
            get
            {
                var dash = Short ? "-" : "--";
                return dash + Name;
            }
        }

        public string Value => IsSet.ToString();

        public bool Match(string name)
        {
            if (name is null) return false;

            if (Short) // short flag
                return name.StartsWith(Name, StringComparison.OrdinalIgnoreCase);
            return string.Compare(Name, name, true) == 0;
        }

        public static implicit operator bool(Flag flag)
        {
            return flag?.IsSet ?? false;
        }

        public override string ToString()
        {
            if (Short)
                return $"-{Name}";
            return $"--{Name}";
        }
    }
}