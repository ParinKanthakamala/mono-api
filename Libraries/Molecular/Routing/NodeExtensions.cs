using System;
using System.Collections.Generic;
using System.Reflection;
using Molecular.Attributes;

namespace Molecular.Routing
{
    public static class NodeExtensions
    {
        public static List<Node> Clone(this List<Node> nodes)
        {
            var result = new List<Node>();
            result.AddRange(nodes);
            return result;
        }

        public static List<Node> CloneAndAppend(this List<Node> nodes, Node tail)
        {
            if (tail is null) return nodes;

            var clone = nodes.Clone();
            clone.Add(tail);
            return clone;
        }

        public static Node TryCreateRoutingNode(this MethodInfo method)
        {
            var command = method.GetCustomAttribute<Command>();
            if (command is null) return null;

            var names = command.IsGeneric ? new[] {method.Name} : command.Names;
            var node = new Node(names);
            return node;
        }

        public static Node TryCreateRoutingNode(this Type type)
        {
            var command = type.GetCustomAttribute<Command>();
            if (command is null) return null;

            var names = command.IsGeneric ? new[] {type.Name} : command.Names;
            var node = new Node(names);
            return node;
        }

        //public static void CreateNode(this Node parent, Command command, Help help)
        //{
        //    if (!command.IsGeneric)
        //    {
        //        var child = new Node(command.Names);
        //        parent.Add(child);
        //    }
        //}

        //public static void CreateNode(this Node parent, Command command, MethodInfo method, Help help)
        //{
        //    var node = command.IsGeneric ? new Node(method.Name) : new Node(command.Names);

        //    node.Endpoint = new Endpoint
        //    {
        //        Method = method,
        //        Commands = Commands(parent, node).ToArray(),
        //        Description = method.GetCustomAttribute<Help>()?.Description
        //    };

        //    parent.Add(node);
        //}
    }
}