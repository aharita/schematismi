namespace ConfigurationTool.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using ConfigurationTool.CommandLine;

    [TestFixture]
    public class ConfigurationToolTests
    {
        [Test]
        public void Test()
        {
            Options options = new Options
            {
                InputFile = "SampleConfiguration.xml"
            };

            //ConfigurationTool.Program.Run()

            //Assert.AreEqual(250.00F, destination.Balance);
            //Assert.AreEqual(100.00F, source.Balance);
        }
    }
}
