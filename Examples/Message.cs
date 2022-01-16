using Molecular.Attributes;

namespace Hello
{
    [Module]
    public class Message
    {
        [Module]
        public string show()
        {
            return "Hello from example.";
        }
    }
}