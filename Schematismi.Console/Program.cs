using System;
using CommandLine;
using Schematismi.Common;
using Schematismi.Console.CommandLine;

namespace Schematismi.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new Options();
            ICommandLineParser parser = new CommandLineParser();

            if (parser.ParseArguments(args, options))
            {
                new ReplaceRules().Execute(options.InputFile);
            }
            else
            {
                System.Console.WriteLine(options.GetUsage());
            }

            System.Console.ReadLine();
        }
    }
}
