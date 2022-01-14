using System;

namespace Gateway.Attributes
{
    public class Module: Attribute
    {
        public string Title { get; }

        
        public Module(string title = null)
        {
            this.Title = title;
            
        }
    }


}