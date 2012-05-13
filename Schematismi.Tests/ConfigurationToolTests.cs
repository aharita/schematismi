﻿using System.Xml.Linq;
using System.Xml.XPath;
using NUnit.Framework;
using Schematismi.Common;

namespace Schematismi.Tests
{
    [TestFixture]
    public class ConfigurationToolTests
    {
        private readonly ReplaceRules replaceRules = new ReplaceRules();

        [Test]
        public void AllChangesTest()
        {
            replaceRules.Execute("TestFiles/Test1.xml");
            XDocument doc = XDocument.Load("TestFiles/db.config");

            Assert.AreEqual(
                doc.XPathSelectElement(@"/connectionStrings/add[@name='Default']").Attribute("connectionString").Value,
                "Server=DEFAULT;Database=DEFAULT;uid=DEFAULT;pwd=DEFAULT;");

            Assert.AreEqual(
                doc.XPathSelectElement(@"/connectionStrings/add[@name='Other']").Attribute("connectionString").Value,
                "Server=OTHER;Database=OTHER;uid=OTHER;pwd=OTHER;");

            Assert.AreEqual(
                doc.XPathSelectElement(@"/connectionStrings/myElement[@name='test']").Value,
                "NEW VALUE");
        }

        [Test]
        public void SomeChangesTest()
        {
            replaceRules.Execute("TestFiles/Test2.xml");
            XDocument doc = XDocument.Load("TestFiles/db2.config");

            Assert.AreEqual(
                doc.XPathSelectElement(@"/connectionStrings/add[@name='Default']").Attribute("connectionString").Value,
                "Server=DEFAULT;Database=DEFAULT;uid=DEFAULT;pwd=DEFAULT;");

            Assert.AreEqual(
                doc.XPathSelectElement(@"/connectionStrings/add[@name='Other']").Attribute("connectionString").Value,
                "Server=SERVER;Database=DATABASE;uid=USER;pwd=PASSWORD;");

            Assert.AreEqual(
                doc.XPathSelectElement(@"/connectionStrings/myElement[@name='test']").Value,
                "NO CHANGE");
        }
    }
}
