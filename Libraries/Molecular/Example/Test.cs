using Molecular.Attributes;

namespace Molecular.Example
{
    [Module]
    public class Test
    {
        [Module]
        public string Message()
        {
            return "test message";
        }
    }
}