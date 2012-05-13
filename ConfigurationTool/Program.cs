using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using ConfigurationTool.CommandLine;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Text.RegularExpressions;
using ConfigurationTool.Common.Utils;
using ConfigurationTool.Common.Entities;

namespace ConfigurationTool
{
    public class Program
    {
        public static void Main(string[] args)
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

        public static void Run(Options options)
        {
            var result = SerializerHelper.DeserializeFromPath<ConfigurationToolElement>(options.InputFile);
            XDocument doc;

            foreach (var app in result.Applications)
            {
                foreach (var conf in app.ConfigElements)
                {
                    doc = XDocument.Load(conf.FileName);

                    foreach (var attr in conf.Attributes)
                    {
                        doc.XPathSelectElement(attr.XPath).Attribute(attr.Attribute).Value = attr.Value;
                    }

                    foreach (var ele in conf.Elements)
                    {
                        doc.XPathSelectElement(ele.XPath).Value = ele.Value;
                    }

                    // save file
                    doc.Save(conf.FileName);
                }
            }
        }
    }
}
