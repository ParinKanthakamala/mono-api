using System.Collections.Generic;

namespace Molecular.Documentation
{
    public class MemberDoc
    {
        public string Key;

        public Dictionary<string, string> Params = new();
        public string Text;
    }


    public static class MemberDocExtensions
    {
        public static string GetParamDoc(this MemberDoc doc, string name)
        {
            return doc.Params.TryGetValue(name, out var value) ? value : null;
        }
    }
}