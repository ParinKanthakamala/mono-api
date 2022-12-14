using System;
using Molecular.Utils;

namespace Molecular.Routing
{
    public static class DefaultExceptionHandler
    {
        public static void Handle(Router router, Exception e)
        {
            RoutingWriter.WriteException(e, router.DebugMode); //todo: re-enable through parameter later.
            Environment.Exit(-1);
        }
    }
}