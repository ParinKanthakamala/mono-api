using System;

namespace Molecular.Attributes
{
    public class Module : Attribute
    {
        public Module(string title = null)
        {
            Title = title;
        }

        public string Title { get; }
    }
}