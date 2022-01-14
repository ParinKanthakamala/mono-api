﻿using System;
using Gateway.Arguments;

namespace Gateway.Attributes
{
    public class Capture : Attribute
    {
        private string[] Values;

        public Capture(params string[] values)
        {
            this.Values = values;
        }

        public bool Match(Parameters.Arguments arguments)
        {
            foreach(var argument in arguments)
            {
                if (Match(argument)) return true;
            }
            return false;
        }

        public bool Match(IArgument argument)
        {
            foreach (var value in Values)
            {
                if (string.Compare(argument.Original, value, ignoreCase: true) == 0) return true;
            }
            return false;
        }
    }
}
