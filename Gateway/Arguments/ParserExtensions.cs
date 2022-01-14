﻿using System;

namespace Gateway.Arguments
{
    public static class ParserExtensions
    {
        public static Parameters.Arguments Parse(this ArgumentParser parser, string s)
        {
            var args = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return parser.Parse(args);
        }
    }
}