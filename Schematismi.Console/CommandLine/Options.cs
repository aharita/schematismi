using CommandLine;
using CommandLine.Text;

namespace Schematismi.Console.CommandLine
{
    public class Options
    {
        private static readonly HeadingInfo headingInfo = new HeadingInfo("Schematismi", "0.1");

        [Option("i", "input", Required = true, HelpText = "XML configuration file to read.")]
        public string InputFile = null;

        [HelpOption(HelpText = "Dispaly this help screen.")]
        public string GetUsage()
        {
            var help = new HelpText(Options.headingInfo);
            help.AdditionalNewLineAfterOption = true;
            help.Copyright = new CopyrightInfo("aharita", 1983, 2012);
            help.AddPreOptionsLine("Post installation configuration tool");
            //help.AddPreOptionsLine("Usage: SampleApp -rMyData.in -wMyData.out --calculate");
            //help.AddPreOptionsLine(string.Format("       SampleApp -rMyData.in -i -j{0} file0.def file1.def", 9.7));
            //help.AddPreOptionsLine("       SampleApp -rMath.xml -wReport.bin -o *;/;+;-");
            help.AddOptions(this);

            return help;
        }
    }
}
