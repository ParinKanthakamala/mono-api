using RestSharp;
using Shared.Entities;

namespace Shared.Core
{
    public class MyModel
    {
        public MyContext db = new();

        public T Load<T>(string api_url, Method method, object args)
        {
            return default;
        }
    }
}