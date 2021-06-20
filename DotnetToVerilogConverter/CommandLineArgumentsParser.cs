using System;
using System.Data.Common;

namespace DotnetToVerilogConverter
{
    public class CommandLineArgumentsParser
    {
        public CommandLineArgumentsParser(string defaultInputFileName = "", string defaultOutputFileName = "")
        {
            InputFileName = defaultInputFileName;
            OutputFileName = defaultOutputFileName;
        }
        public string InputFileName { get; private set; }
        public string OutputFileName { get; private set; }

        public void ParseArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-in":
                        try
                        {
                            InputFileName = args[i + 1];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            throw new ArgumentException("no input file name!");
                        }
                        break;
                    case  "-out":
                        try
                        {
                            OutputFileName = args[i + 1];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            throw new ArgumentException("no output file name!");
                        }
                        break;
                }
            }
        }
    }
}