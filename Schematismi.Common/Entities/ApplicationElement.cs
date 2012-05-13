namespace Schematismi.Common.Entities
{
    using System.Xml.Serialization;

    public class ApplicationElement
    {
        [XmlAttributeAttribute("name")]
        public string Name { get; set; }

        [XmlElementAttribute("config")]
        public ConfigElement[] ConfigElements { get; set; }
    }
}