namespace Schematismi.Common.Entities
{
    using System.Xml.Serialization;

    public class ElementElement
    {
        [XmlAttribute("xpath")]
        public string XPath { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}