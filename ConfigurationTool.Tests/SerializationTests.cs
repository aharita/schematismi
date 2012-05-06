// -----------------------------------------------------------------------
// <copyright file="SerializationTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ConfigurationTool.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using ConfigurationTool.Common.Utils;
    using ConfigurationTool.Common.Entities;
    using System.Xml.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class SerializationTests
    {
        [Test]
        public void SerializationConsistencyTest()
        {
            var result = SerializerHelper.DeserializeFromPath<ConfigurationToolElement>("TestFiles/Test3.xml");

            Assert.AreEqual(2, result.Applications.Length);
            Assert.AreEqual(2, result.Applications[0].ConfigElements.Length);
            Assert.AreEqual(3, result.Applications[0].ConfigElements[1].Attributes.Length);
            Assert.AreEqual("Server=DEFAULT;Database=DEFAULT;uid=DEFAULT;pwd=DEFAULT;", result.Applications[0].ConfigElements[1].Attributes[0].Value);
        }
    }
}
