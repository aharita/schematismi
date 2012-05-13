namespace Schematismi.Tests
{
    using NUnit.Framework;
    using Schematismi.Common.Entities;
    using Schematismi.Common.Utils;

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