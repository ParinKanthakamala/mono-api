using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Molecular.Documentation
{
    public class DocumentationBuilder
    {
        private readonly Documentation documentation = new();

        public DocumentationBuilder Add(Assembly assembly)
        {
            var xdoc = ReadXmlDocumentation(assembly);
            if (xdoc is not null)
            {
                var items = ReadMembersDocumentation(xdoc);
                foreach (var item in items) documentation.Add(item);
            }

            return this;
        }

        public Documentation Build()
        {
            return documentation;
        }

        private static string GetDirectoryPath(Assembly assembly)
        {
            var codeBase = assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static XDocument ReadXmlDocumentation(Assembly assembly)
        {
            var directoryPath = GetDirectoryPath(assembly);
            var xmlFilePath = Path.Combine(directoryPath, assembly.GetName().Name + ".xml");
            if (File.Exists(xmlFilePath))
                return ReadXmlDocumentation(File.ReadAllText(xmlFilePath));
            return null;
        }

        public static XDocument ReadXmlDocumentation(string content)
        {
            using var reader = new StringReader(content);
            var document = XDocument.Load(reader);
            return document;
        }

        public IEnumerable<MemberDoc> ReadMembersDocumentation(XDocument xdoc)
        {
            var membernodes = xdoc.XPathSelectElements("doc/members/member").ToList();

            foreach (var membernode in membernodes)
            {
                var doc = new MemberDoc();

                doc.Key = membernode?.Attribute("name")?.Value;
                doc.Text = DocKeys.ConsiseTrim(membernode?.Element("summary")?.Value);

                var paramnodes = membernode?.Elements("param");

                foreach (var paramnode in paramnodes)
                {
                    var name = paramnode.Attribute("name")?.Value;
                    var summary = paramnode?.Value?.Trim();
                    doc.Params.Add(name, summary);
                }

                yield return doc;
            }
        }
    }
}