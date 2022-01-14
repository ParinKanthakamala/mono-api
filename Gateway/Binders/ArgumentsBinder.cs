﻿using System;
using Gateway.Binding;
using Gateway.Parameters;

namespace Gateway.Binders
{
    public class ArgumentsBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type) => type == typeof(Parameters.Arguments);

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            used = arguments.Count;
            result = new Parameters.Arguments(arguments);
            return BindStatus.Success;
        }
    }
}