using System;

namespace Web.Shared.Libraries.Extensions
{
    public static class NumberExtensions
    {
        public static void ForEach(this int source, Action<int> action)
        {
            for (var i = 0; i < source; i++) action!(i);
        }
    }
}