using System;

namespace Molecular.Parameters
{
    public class Parameter
    {
        public string AltName;
        public string Name;
        public bool Optional;
        public Type Type;

        public override string ToString()
        {
            var optional = Optional ? "(optional) " : "";
            return $"{optional}{Type.Name} {Name}";
        }

        public static Parameter Create<T>(string name, string alt = null, bool optional = false)
        {
            return new Parameter
            {
                Name = name,
                Type = typeof(T),
                AltName = alt,
                Optional = optional
            };
        }
    }
}