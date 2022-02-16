using System;
using System.Collections.Generic;

namespace Client.Library
{
    public class AppObjectCache
    {
        private readonly Dictionary<string, string> _data = new();
        private readonly Dictionary<string, Dictionary<string, object>> cache = new();

        public int cache_hits;
        public int cache_misses;

        public string this[string key]
        {
            get => this[key];
            set => _data.Add(key, value);
        }

        public bool ContainsKey(string name)
        {
            return _data.ContainsKey(name);
        }

        public void Remove(string name)
        {
            _data.Remove(name);
        }

        public bool Add(string key, object data, string group = "default")
        {
            if (string.IsNullOrEmpty(group)) group = "default";

            if (_exists(key, group)) return false;

            return set(key, data, group);
        }

        public object decr(string key, int offset = 1, string group = "default")
        {
            if (string.IsNullOrEmpty(group)) group = "default";

            if (!_exists(key, group)) return false;

            if (!int.TryParse(Convert.ToString(cache[group][key]), out var number)) cache[group][key] = 0;

            cache[group][key] = Convert.ToInt32(cache[group][key]) - offset;

            if (Convert.ToInt32(cache[group][key]) < 0) cache[group][key] = 0;

            return cache[group][key];
        }

        public bool delete(string group, string key)
        {
            if (string.IsNullOrEmpty(group)) group = "default";

            if (!_exists(key, group)) return false;

            return true;
        }

        public bool flush()
        {
            cache.Clear();

            return true;
        }

        public T get<T>(string key, string group = "default")
        {
            var output = false;
            if (string.IsNullOrEmpty(group)) group = "default";
            if (_exists(key, group))
                cache_hits += 1;
            // return cache[group][key];
            cache_misses += 1;
            return (T) Convert.ChangeType(output, typeof(T));
        }

        public object incr(string key, int offset = 1, string group = "default")
        {
            if (string.IsNullOrEmpty(group)) group = "default";

            if (!_exists(key, group)) return null;

            if (!int.TryParse(Convert.ToString(cache[group][key]), out var number)) cache[group][key] = 0;


            cache[group][key] = Convert.ToInt32(cache[group][key]) + offset;

            if (Convert.ToInt32(cache[group][key]) < 0) cache[group][key] = 0;

            return cache[group][key];
        }

        public bool replace(string key, string data, string group = "default")
        {
            if (string.IsNullOrEmpty(group)) group = "default";

            if (!_exists(group, key)) return false;

            return set(group, key, data);
        }

        public bool set(string key, object data, string group = "default")
        {
            if (string.IsNullOrEmpty(group)) group = "default";

            try
            {
                if (!cache[group].ContainsKey(key))
                {
                }

                cache[group][key] = data;
            }
            catch
            {
            }

            return true;
        }

        protected bool _exists(string key, string group = "default")
        {
            if (cache.ContainsKey(group)) return cache[group].ContainsKey(key);

            return false;
        }
    }

    public static class AppObjectCacheExtension
    {
        private static AppObjectCache _instance;

        public static AppObjectCache app_object_cache(this object helper)
        {
            return _instance ??= new AppObjectCache();
        }
    }
}