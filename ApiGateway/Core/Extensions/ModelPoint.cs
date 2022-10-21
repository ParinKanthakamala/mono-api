using ApiGateway.Entities;

namespace ApiGateway.Core.Extensions
{
    public class ModelPoint
    {
        public Contacts contact = new Contacts();
        public Users current_user = new Users();
        public Clients client = new Clients();
    }

    public static class ModelPointExtension
    {
        private static ModelPoint _instance = null;

        public static ModelPoint model_point()
        {
            return _instance ??= new ModelPoint();
        }
    }
}