using System;

namespace Molecular.Attributes
{
    /// <summary>
    ///     Sepcifies the help in the help list.
    /// </summary>
    public class Help : Attribute
    {
        public Help(string description = null)
        {
            Description = description;
        }

        public string Description { get; }
    }
}