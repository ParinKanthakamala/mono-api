using System;

namespace Molecular.Helpers
{
    public class ClassHelper
    {
        public object GetInstance(string strFullyQualifiedName)
        {
            var type = Type.GetType(strFullyQualifiedName);
            if (type != null) return Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}