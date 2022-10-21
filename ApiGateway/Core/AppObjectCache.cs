using NotImplementedException = System.NotImplementedException;

namespace ApiGateway.Core
{
    public class AppObjectCache
    {
        private static AppObjectCache instance;

        public static AppObjectCache app_object_cache()
        {
            return instance ??= new AppObjectCache();
        }

        public void set(string currency, object currenciesList)
        {
            throw new NotImplementedException();
        }

        public object get(string currenciesData)
        {
            throw new NotImplementedException();
        }

        public void add(string currenciesData, object currencies)
        {
            throw new NotImplementedException();
        }
    }
}