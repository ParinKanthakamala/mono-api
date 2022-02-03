using System;

namespace Tools.Label
{
    public class ComponentExtension : IExtension
    {
        public object Component { get; set; }
        public Action<object> Action { get; set; }
    }
}