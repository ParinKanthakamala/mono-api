using System;

namespace Web.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyAttribute : Attribute
    {
        public AssemblyAttribute(string version)
        {
            Version = version;
        }

        public string Version { get; set; }
    }
}