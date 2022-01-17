﻿using Molecular.Attributes;

namespace Hello
{
    /// <summary>
    /// This module shows how you can create sub commands through sub classing
    /// </summary>
    [Module("Sub")]
    public class MainSubCommands
    {
        /// <summary>
        /// Greet command (top level)
        /// </summary>
        [Command]
        public void Greet()
        {
        }

        /// <summary>
        /// Greet command with parameter
        /// </summary>
        /// <param name="hello"></param>
        [Command]
        public void Greet(string hello)
        {
            System.Console.WriteLine("hello " + hello);
        }

        /// <summary>
        /// Documentation for main. Yada
        /// </summary>
        [Command, Help("Help for main")]
        public class Main
        {
            /// <summary>
            /// Documentation for sub. Yadayada
            /// </summary>
            [Command("Sub"), Help("Help for sub")]
            public void Sub()
            {
                System.Console.WriteLine("Main... sub...");
            }

            /// <summary>
            /// Sub command 2
            /// </summary>
            [Command, Help("Help for sub2")]
            public void Sub2()
            {
                System.Console.WriteLine("Main... sub2...");
            }
        }
    }
}