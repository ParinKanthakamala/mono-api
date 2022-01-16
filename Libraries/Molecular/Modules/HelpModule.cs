using Molecular.Attributes;
using Molecular.Routing;
using Molecular.Utils;

namespace Molecular.Modules
{
    /// <summary>
    /// This is the default help module, that is in included in your routing system when you use
    /// RouteBuilder.AddHelp()
    /// </summary>
    [Module("Help")]
    public class HelpModule
    {
        private Router router;

        public HelpModule(Router router)
        {
            this.router = router;
        }

        [Command("help"), Help("Provides this help list or detailed help about a command")]
        public void Help(Parameters.Arguments args = null)
        {
            if (args is null || args.Count == 0)
            {
                router.Writer.WriteRoutes(router);
            }
            else
            {
                var result = router.Bind(args);
                router.Writer.WriteRouteHelp(result);
            }
        }

        [Command, Capture("?", "--help", "-?", "-h")]
        public void CaptureHelp(Parameters.Arguments args = null)
        {
            if (args is null || args.Count == 0)
            {
                router.Writer.WriteRoutes(router);
            }
            else
            {
                var result = router.Bind(args);
                router.Writer.WriteRouteHelp(result);
            }
        }

    }



}