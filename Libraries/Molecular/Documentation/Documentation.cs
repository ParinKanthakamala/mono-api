using System.Collections.Generic;
using System.Reflection;
using Molecular.Routing;

namespace Molecular.Documentation
{
    public class Documentation
    {
        private readonly Dictionary<string, MemberDoc> xdoc = new();

        public void Add(MemberDoc doc)
        {
            xdoc.Add(doc.Key, doc);
        }

        public string GetCommandDoc(Route route)
        {
            var doc = GetDoc(route.Method);
            return doc.Text;
        }

        private MemberDoc GetEntry(string key)
        {
            return xdoc.TryGetValue(key, out var doc) ? doc : null;
        }

        public MemberDoc GetDoc(MethodInfo method)
        {
            var key = DocKeys.BuildMethodKey(method);
            return GetEntry(key);
        }

        public MemberDoc GetMemberDoc(MemberInfo member)
        {
            var key = DocKeys.BuildMemberKey(member);
            var doc = GetEntry(key);
            return doc;
        }
    }

    public static class DocumentationExtensions
    {
        public static MemberDoc GetDoc(this Documentation documentation, Route route)
        {
            var doc = documentation.GetDoc(route.Method);
            return doc;
        }
    }
}