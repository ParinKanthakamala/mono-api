using System;

namespace Molecular.Attributes
{
    /// <summary>
    /// Sepcifies the help in the help list.
    /// </summary>
    public class Help : Attribute
    {
        public string Description { get; }

        public Help(string description = null)
        {
            Description = description;
        }

        
    }


}