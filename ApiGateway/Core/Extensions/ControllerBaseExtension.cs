using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ApiGateway.Core.Extensions
{
    public static class ControllerBaseExtension
    {
        public static string ApiName = "";

         

        // public ApiGateway(HttpContext httpContext)
        // {
        //     source.dataHub = dataHub;
        //     // Context = httpContext;
        //     Response = Context.Response;
        //     Request = Context.Request;
        //     originalPath = Convert.ToString(Request.Path.Value);
        //     Console.WriteLine(ApiName);
        // }
        
        
        

        public static List<string> Segments(this ControllerBase source)
        {
            var originalPath = Convert.ToString(source.Request.Path.Value);
            return !string.IsNullOrEmpty(originalPath)
                ? originalPath.Split("/").ToList().Where(el => !string.IsNullOrEmpty(el)).ToList()
                : new List<string>();
        }


        public static string GetApiName(this ControllerBase source)
        {
            var value = source.Request.Path.HasValue ? source.Request.Path.Value : "";
            if (value == null) return "unknow-service";
            var temp = value.Split('/').Where(item => !string.IsNullOrEmpty(item)).ToList();
            return Convert.ToString(temp[0]) + "-service";
        }

        public static string GetRoute(this ControllerBase source)
        {
            var value = source.Request.Path.HasValue ? source.Request.Path.Value : "";
            if (value == null) return "";
            var temp = value.Split('/').Where(item => !string.IsNullOrEmpty(item)).ToList();
            temp.RemoveAt(0);
            return string.Join("/", temp);
        }

        public static object GetQuery(this ControllerBase source)
        {
            return source.Request.Query.ToDictionary<KeyValuePair<string, StringValues>, string, object>(
                query =>
                    query.Key, query => query.Value.Count == 1 ? query.Value[0] : query.Value);
        }
    }
}