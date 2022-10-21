using System;
using System.Collections.Generic;

namespace ApiGateway.Core
{
    public class MyHooks
    {
        private static MyHooks instance = null;

        public static MyHooks hooks() => instance ??= new MyHooks();

        public object DoAction(string beforeInsertViewsTracking, params object[] o)
        {
            return null;
        }

        public object ApplyFilters(string allCountries, object entry = null)
        {
            return null;
        }

        public bool HasFilter(string adminBodyClass, string addHasDeprecatedErrorsAdminBodyClass = "")
        {
            return false;
        }

        public void AddAction(string activate, Func<object, object> function)
        {
        }

        public string ApplyFiltersRefArray(string tag, List<string> args)
        {
            return "";
        }

        public void DoActionRefArray(string tag, List<string> args)
        {
        }

        public bool HasAction(string tag, object pa = null)
        {
            return false;
        }
    }
}