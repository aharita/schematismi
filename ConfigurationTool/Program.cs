using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using ConfigurationTool.CommandLine;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace ConfigurationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            ICommandLineParser parser = new CommandLineParser();
            if (parser.ParseArguments(args, options))
            {
                Run(options);
            }
            else
            {
                Console.WriteLine(options.GetUsage());
            }

            Console.ReadLine();
        }

        private static void Run(Options options)
        {
            XDocument doc = XDocument.Load(options.InputFile);
            XDocument inner;
            string filePath;

            foreach (var app in doc.Descendants("application"))
            {
                foreach (var config in app.Descendants("config"))
                {
                    // open file
                    filePath = config.Attribute("fileName").Value;
                    inner = XDocument.Load(filePath);

                    foreach (var attribute in config.Descendants("attribute"))
                    { 
                        inner.XPathSelectElement(
                            attribute.Attribute("xpath").Value)
                                .Attribute(attribute.Attribute("attribute").Value).Value = attribute.Attribute("value").Value;
                    }

                    foreach (var element in config.Descendants("element"))
                    {
                        inner.XPathSelectElement(element.Attribute("xpath").Value).Value = element.Attribute("value").Value;
                    }

                    // save file
                    inner.Save(filePath);
                }
            }
        }
    }
}
