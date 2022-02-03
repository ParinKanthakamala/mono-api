using System;

namespace Tools.Label
{
    public interface IExtension
    {
        object Component { get; set; }
        Action<object> Action { get; set; }
    }
}