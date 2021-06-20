using System.Collections.Generic;
using System.IO;

namespace DotnetToVerilogConverter
{
    public class VerilogGenerator
    {
        public List<string> GenerateLinesFromTokens(Dictionary<int, LineToken> lineTokens)
        {
            List<string> lines = new List<string>();
            foreach (LineToken lineToken in lineTokens.Values)
            {
                lines.Add(lineToken.GenerateVerilogLine());
            }
            return lines;
        }

        public async void GenerateFile(string fileName, string[] lines)
        {
            await File.WriteAllLinesAsync(fileName, lines);
        }
    }
}