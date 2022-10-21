using NotImplementedException = System.NotImplementedException;

namespace ApiGateway.System
{
    public class Session
    {
        private static Session instance;
        public static Session getInstance() => instance ??= new Session();

        public bool Flashdata(string messageWarning)
        {
            throw new NotImplementedException();
        }

        public void Set(string userId, int userUserId)
        {
            throw new NotImplementedException();
        }

        public bool HasUserdata(string systemPopup)
        {
            throw new NotImplementedException();
        }
    }
}