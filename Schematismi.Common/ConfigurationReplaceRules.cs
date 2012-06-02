using System.Xml.Linq;
using System.Xml.XPath;
using Schematismi.Common.Entities;
using Schematismi.Common.Utils;
using Schematismi.Interfaces;

namespace Schematismi.Common
{
    public class ConfigurationReplaceRules : IConfigurationReplaceRules
    {
        public void Execute(string inputFile)
        {
            var result = SerializerHelper.DeserializeFromPath<ConfigurationToolElement>(inputFile);
            XDocument doc;

            foreach (var app in result.Applications)
            {
                foreach (var conf in app.ConfigElements)
                {
                    doc = XDocument.Load(conf.FileName);

                    foreach (var attr in conf.Attributes)
                    {
                        doc.XPathSelectElement(attr.XPath).Attribute(attr.Attribute).Value = attr.Value;
                    }

                    foreach (var ele in conf.Elements)
                    {
                        doc.XPathSelectElement(ele.XPath).Value = ele.Value;
                    }

                    // save file
                    doc.Save(conf.FileName);
                }
            }
        }
    }
}
