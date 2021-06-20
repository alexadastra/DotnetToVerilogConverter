using System;
using System.Collections.Generic;
using System.IO;

namespace DotnetToVerilogConverter
{
    static class Converter
    {
        static string defaultDotnetFileName = "$HOME/APM_routing.v";
        static string defaultVerilogFileName = "$HOME/apm_router_17_nodes.v";
        
        static void Main(string[] args)
        {
            CommandLineArgumentsParser commandLineArgumentsParser =
                new CommandLineArgumentsParser(defaultDotnetFileName, defaultVerilogFileName);
            commandLineArgumentsParser.ParseArguments(args);

            DotnetParser dotnetParser = new DotnetParser();
            List<string> readStrings = dotnetParser.ParseFile(commandLineArgumentsParser.InputFileName);
            Dictionary<int, LineToken> lineTokens = dotnetParser.TokeniseFile(readStrings);

            VerilogGenerator verilogGenerator = new VerilogGenerator();
            List<string> stringsToWrite = verilogGenerator.GenerateLinesFromTokens(lineTokens);
            verilogGenerator.GenerateFile(commandLineArgumentsParser.OutputFileName, stringsToWrite.ToArray());
        }
    }
}