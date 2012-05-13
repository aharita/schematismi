namespace Schematismi.Common.Entities
{
    using System.Xml.Serialization;

    [XmlType("configurationTool")]
    public class ConfigurationToolElement
    {
        [XmlElementAttribute("application")]
        public ApplicationElement[] Applications { get; set; }
    }
}