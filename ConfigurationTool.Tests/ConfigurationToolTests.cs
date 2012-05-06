using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConfigurationTool.CommandLine;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConfigurationTool.Tests
{
    [TestFixture]
    public class ConfigurationToolTests
    {
        [Test]
        public void AllChangesTest()
        {
            Options options = new Options
            {
                InputFile = "TestFiles/Test1.xml"
            };

            ConfigurationTool.Program.Run(options);
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
            Options options = new Options
            {
                InputFile = "TestFiles/Test2.xml"
            };

            ConfigurationTool.Program.Run(options);
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
