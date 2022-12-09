namespace AoC2022.FileSystem;

public class Directory
{
    private Directory()
    {
    }

    public Directory(string name, Directory? parent)
    {
        Name = name;
        Parent = parent;
    }

    public void AddDirectory(string name) => Directories.Add(new Directory(name, this));

    public void AddFile(int size, string name) => Files.Add(new File(size, name));

    public static Directory CreateRoot() =>
        new()
        {
            Name = "Root"
        };

    public Directory GetDirectory(string name) => Directories.First(_ => _.Name == name);

    public int CalculateSize()
    {
        TotalSize = Files.Sum(_ => _.Size) + Directories.Sum(_ => _.CalculateSize());

        return TotalSize;
    }

    public string Name { get; init; }

    public readonly Directory Parent;
    public  List<Directory> Directories { get; } = new();
    public List<File> Files { get; } = new();
    public int TotalSize { get; private set; }

    public IEnumerable<Directory> GetAllDirectoriesInside()
    {
        var dirs = new List<Directory>(Directories);
        dirs.AddRange(Directories.SelectMany(_ => _.GetAllDirectoriesInside()));
        return dirs;
    }
}