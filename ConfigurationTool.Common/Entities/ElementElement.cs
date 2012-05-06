// -----------------------------------------------------------------------
// <copyright file="ElementElement.cs" company="Microsoft">
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
    public class ElementElement
    {
        [XmlAttribute("xpath")]
        public string XPath { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
