using System;
using System.Linq;
using Molecular.Routing;

namespace Molecular.Utils
{
    public static class DisplayExtensions
    {
        public static string GetCommandPath(this Route route)
        {
            var path = string.Join(" ", route.Nodes.Select(n => n.Names.First())).ToLower();
            return path;
        }

        public static string GetErrorMessage(this Exception exception)
        {
            if (exception.InnerException is null)
                return exception.Message;
            return GetErrorMessage(exception.InnerException);
        }
    }
}