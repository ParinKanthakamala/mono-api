﻿using System;
using System.Collections.Generic;
using Molecular.Routing;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            // list.Add("Sub");
            list.Add("Greet");
            list.Add("maxx");
            Routing.Handle(list.ToArray());
            Console.WriteLine("Examples World!");
        }
    }
}