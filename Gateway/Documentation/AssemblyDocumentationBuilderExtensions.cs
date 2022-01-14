﻿using System.Collections.Generic;
using System.Reflection;

namespace Gateway.Documentation
{
    public static class AssemblyDocumentationBuilderExtensions
    {
        public static DocumentationBuilder Add(this DocumentationBuilder builder, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies) builder.Add(assembly);
            return builder;
        }
    }
}