using System;

namespace Web.Shared.Libraries.Label
{
    public interface IExtension
    {
        object Component { get; set; }
        Action<object> Action { get; set; }
    }
}