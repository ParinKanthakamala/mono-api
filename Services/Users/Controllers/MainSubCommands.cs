using System;
using System.Collections.Generic;
using Molecular.Attributes;
using Molecular.Routing;

namespace Users.Controllers
{
    /// <summary>
    ///     This module shows how you can create sub commands through sub classing
    /// </summary>
    [Module("Sub")]
    public class MainSubCommands
    {
        /// <summary>
        ///     Greet command (top level)
        /// </summary>
        [Command]
        public void Greet()
        {
        }

        /// <summary>
        ///     Greet command with parameter
        /// </summary>
        /// <param name="hello"></param>
        [Command]
        public void Greet(string hello)
        {
            Console.WriteLine("hello " + hello);
        }

        public static void Example()
        {
            var list = new List<string>();
            // list.Add("Sub");
            list.Add("Greet");
            list.Add("maxx");
            Routing.Handle(list.ToArray());
        }

        /// <summary>
        ///     Documentation for main. Yada
        /// </summary>
        [Command]
        [Help("Help for main")]
        public class Main
        {
            /// <summary>
            ///     Documentation for sub. Yadayada
            /// </summary>
            [Command("Sub")]
            [Help("Help for sub")]
            public void Sub()
            {
                Console.WriteLine("Main... sub...");
            }

            /// <summary>
            ///     Sub command 2
            /// </summary>
            [Command]
            [Help("Help for sub2")]
            public void Sub2()
            {
                Console.WriteLine("Main... sub2...");
            }
        }
    }
}