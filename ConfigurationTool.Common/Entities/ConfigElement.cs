// -----------------------------------------------------------------------
// <copyright file="ConfigElement.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ConfigurationTool.Common.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
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
