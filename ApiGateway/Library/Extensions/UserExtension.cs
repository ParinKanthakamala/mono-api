using Newtonsoft.Json;

namespace ApiGateway.Library.Extensions
{
    public static class UserExtension
    {
        public static object JsonObject(object input)
        {
            return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(input));
        }

        // public static dynamic Removes(this User user, params string[] keys)
        // {
        //     var obj = JsonObject(user);
        //     var dict = new Dictionary<string, object>();
        //     foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(obj))
        //         if (!keys.ToList().Contains(desc.Name))
        //             dict[desc.Name] = desc.GetValue(obj);
        //
        //     return dict;
        // }
    }
}