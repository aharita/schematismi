// -----------------------------------------------------------------------
// <copyright file="ApplicationElement.cs" company="Microsoft">
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
    public class ApplicationElement
    {
        [XmlAttributeAttribute("name")]
        public string Name { get; set; }

        [XmlElementAttribute("config")]
        public ConfigElement[] ConfigElements { get; set; }
    }
}
