using System;

namespace Molecular.Attributes
{
    public class Alt : Attribute
    {
        public string Name { get; }

        public Alt(string name)
        {
            this.Name = name;
        }
    }
}