using System;

namespace Molecular.Attributes
{
    /// <summary>
    /// Defines an alternative name for a parameter
    /// </summary>
    public class Alt : Attribute
    {
        public string Name { get; }

        public Alt(string name)
        {
            Name = name;
        }
    }
}