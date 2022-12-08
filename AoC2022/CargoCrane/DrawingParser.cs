namespace AoC2022.CargoCrane;

public class DrawingParser
{
    public static (Hold hold, IEnumerable<string> commands) From(string filePath)
    {
        string[] data = ReadAllLines(filePath);


        var line = 0;
        var stacks = new List<string>();

        while (string.IsNullOrWhiteSpace(data[line]) is false && data[line].Any(char.IsNumber) is false)
        {
            var number = -1;
            stacks.Add("");
            for (int i = 1; i < data[line].Length; i += 4)
            {
                number++;
                
                if (stacks.ElementAtOrDefault(number) is null)
                {
                    stacks.Add("");
                }
                
                if (char.IsWhiteSpace((data[line][i])))
                {
                    continue;
                }

                stacks[number] += data[line][i].ToString();
            }

            line++;
        }

        var hold = new Hold(stacks.Where(_ => string.IsNullOrEmpty(_) is false).Select(stackString =>
            new Stack(stackString.Reverse().Select(_ => _.ToString()).ToArray())).ToArray());

        var commands = data.Skip(line+2);
        
        return (hold, commands);
    }

    private static int GetLineNumberIndex(string[][] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i][1] == "1") return i;
        }

        throw new Exception();
    }

    private static string[] ReadAllLines(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
}