namespace Schematismi.Common.Entities
{
    using System.Xml.Serialization;

    public class AttributeElement
    {
        [XmlAttribute("xpath")]
        public string XPath { get; set; }

        [XmlAttribute("attribute")]
        public string Attribute { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}