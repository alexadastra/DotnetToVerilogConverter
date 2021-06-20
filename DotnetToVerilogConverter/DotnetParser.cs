using System;
using System.Collections.Generic;
using System.IO;

namespace DotnetToVerilogConverter
{
    public class DotnetParser
    {
        public List<string> ParseFile(string fileName)
        {
            List<string> FileLines = new List<string>();
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    FileLines.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Done reading file lines.");
            }

            return FileLines;
        }

        public Dictionary<int, LineToken> TokeniseFile(List<String> fileLines)
        {
            Dictionary<int, LineToken> lineTokens = new Dictionary<int, LineToken>();
            for (int i = 0; i < fileLines.Count; i++)
            {
                lineTokens.Add(i, new LineToken());
            }
            return lineTokens;
        }
    }
}