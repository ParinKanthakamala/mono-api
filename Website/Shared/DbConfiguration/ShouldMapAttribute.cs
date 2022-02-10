using System;

namespace Shared.DbConfiguration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ShouldMapAttribute : Attribute
    {
    }
}