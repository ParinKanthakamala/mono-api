using System;
using System.Collections.Generic;
using System.Globalization;
using Client.Helpers;

namespace Client.Library
{
    public class Hooks
    {
        public Dictionary<string, Func<dynamic, dynamic>> hook = new();


        public bool has_filter(string tag, params object[] function_to_check)
        {
            return false;
        }


        public bool add_filter(string tag, Func<string, string> function_to_add, int priority = 10,
            int accepted_args = 1)
        {
            return true;
        }


        public bool has_action(string tag, Func<dynamic, dynamic> function_to_check = null)
        {
            return has_filter(tag, function_to_check);
        }


        public T ApplyFilters<T>(string tag, T value = default, string parent_slug = null)
        {
            if (hook.ContainsKey(tag)) hook.Remove(tag);

            return (T) Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }

        public string DoAction(string key, params object[] args)
        {
            if (hook.ContainsKey(key)) hook[key].Invoke(args);

            return "";
        }

        public void AddAction(string key, Func<dynamic, dynamic> action)
        {
            hook.Add(key, action);
        }


        public void do_action_ref_array(string tag, params object[] args)
        {
        }

        public string apply_filters_ref_array(string tag, params object[] args)
        {
            return null;
        }
    }


    public static class HooksExtensions
    {
        private static Hooks _hooks;

        public static Hooks hooks(this Helper helper)
        {
            return _hooks ??= new Hooks();
        }
    }
}