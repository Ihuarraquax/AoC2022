namespace AoC2022.FileSystem;

public class Path
{
    public Directory RootDirectory { get; }

    public Directory CurrentDirectory { get; private set; }

    public Path(Directory rootDirectory)
    {
        RootDirectory = rootDirectory;
    }

    public void GoToRoot()
    {
        CurrentDirectory = RootDirectory;
    }

    public void MoveIn(string directory)
    {
        CurrentDirectory = CurrentDirectory.GetDirectory(directory);
    }

    public void MoveOut()
    {
        CurrentDirectory = CurrentDirectory.Parent;
    }

    public IEnumerable<Directory> FindDirectoriesWhere(Func<Directory, bool> func)
    {
        return RootDirectory.GetAllDirectoriesInside().Where(func);
    }
}