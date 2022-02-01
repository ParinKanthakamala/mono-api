using System;

namespace Web.Shared.DbConfiguration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullableAttribute : Attribute
    {
    }
}