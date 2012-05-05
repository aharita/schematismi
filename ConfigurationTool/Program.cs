using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using ConfigurationTool.CommandLine;

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
        }

        private static void Run(Options options)
        {
            
        }
    }
}
