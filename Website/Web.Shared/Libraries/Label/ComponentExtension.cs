using System;

namespace Web.Shared.Libraries.Label
{
    public class ComponentExtension : IExtension
    {
        public object Component { get; set; }
        public Action<object> Action { get; set; }
    }
}