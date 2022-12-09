namespace AoC2022.FileSystem;

public class FileSystemExplorer
{
    public Path Path { get; }
    private readonly Queue<string> outputQueue;

    public FileSystemExplorer(IEnumerable<string> terminalOutput)
    {
        outputQueue = new Queue<string>(terminalOutput);
        Path = new Path(Directory.CreateRoot());
        while (outputQueue.Count > 0)
        {
            BacktrackCommand(outputQueue.Dequeue());
        }

        Path.RootDirectory.CalculateSize();
    }

    private void BacktrackCommand(string command)
    {
        var word = command.Split(' ');

        switch (word[1])
        {
            case "cd":
                ChangeDirectory(word[2]);
                return;
            case "ls":
                List();
                return;
        }
    }
    
    private void ChangeDirectory(string argument)
    {
        switch (argument)
        {
            case "..":
                Path.MoveOut();
                return;
            case "/":
                Path.GoToRoot();
                return;
            default:
                Path.MoveIn(argument);
                return;
        }
    }
    private void List()
    {
        while (outputQueue.TryPeek(out var result) && result.StartsWith('$') is false)
        {
            var listItem = outputQueue.Dequeue();

            var listItemTokens = listItem.Split(' ');

            if (listItemTokens[0] == "dir")
            {
                Path.CurrentDirectory.AddDirectory(listItemTokens[1]);
                continue;
            }

            Path.CurrentDirectory.AddFile(int.Parse(listItemTokens[0]), listItemTokens[1]);
        }
    }
}