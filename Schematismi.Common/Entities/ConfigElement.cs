namespace Schematismi.Common.Entities
{
    using System.Xml.Serialization;

    public class ConfigElement
    {
        [XmlAttributeAttribute("fileName")]
        public string FileName { get; set; }

        [XmlArray("attributes")]
        [XmlArrayItemAttribute("attribute")]
        public AttributeElement[] Attributes { get; set; }

        [XmlArray("elements")]
        [XmlArrayItemAttribute("element")]
        public ElementElement[] Elements { get; set; }
    }
}