using NotImplementedException = System.NotImplementedException;

namespace ApiGateway.System
{
    public class Input
    {
        private static Input instance;

        public static Input getInstance => instance ??= new Input();
        public object post { get; set; }

        public string ip_address()
        {
            throw new NotImplementedException();
        }
    }
}