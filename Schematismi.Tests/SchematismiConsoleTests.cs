using System.Xml.Linq;
using System.Xml.XPath;
using NUnit.Framework;
using Schematismi.Common;
using Schematismi.Interfaces;

namespace Schematismi.Tests
{
    [TestFixture]
    public class SchematismiConsoleTests
    {
        private readonly IConfigurationReplaceRules _replaceRules = new ConfigurationReplaceRules();

        [Test]
        public void AllChangesTest()
        {
            _replaceRules.Execute("TestFiles/Test1.xml");
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
            _replaceRules.Execute("TestFiles/Test2.xml");
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
