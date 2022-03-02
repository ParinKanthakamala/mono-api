using System;

namespace Molecular.Attributes
{
    public class Alt : Attribute
    {
        public Alt(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}