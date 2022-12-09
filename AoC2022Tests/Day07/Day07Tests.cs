using AoC2022.FileSystem;

namespace AoC2022Tests.Day07;

public class Day07Tests
{
    [Fact]
    public void Test1()
    {
        var explorer = new FileSystemExplorer(System.IO.File.ReadAllLines("Day07/test.txt"));

        var root = explorer.Path.RootDirectory;
        root.Directories.Should().HaveCount(2);
        root.Files.Should().HaveCount(2);
        root.Files.Should().ContainSingle(_ => _.Name == "b.txt").Which.Size.Should().Be(14848514);
        root.Files.Should().ContainSingle(_ => _.Name == "c.dat").Which.Size.Should().Be(8504156);

        var a = root.Directories.Should().ContainSingle(_ => _.Name == "a").Which;
        a.Files.Should().ContainSingle(_ => _.Name == "f").Which.Size.Should().Be(29116);
        a.Files.Should().ContainSingle(_ => _.Name == "g").Which.Size.Should().Be(2557);
        a.Files.Should().ContainSingle(_ => _.Name == "h.lst").Which.Size.Should().Be(62596);
        
        var d = root.Directories.Should().ContainSingle(_ => _.Name == "d").Which;
        d.Files.Should().ContainSingle(_ => _.Name == "j").Which.Size.Should().Be(4060174);
        d.Files.Should().ContainSingle(_ => _.Name == "d.log").Which.Size.Should().Be(8033020);
        d.Files.Should().ContainSingle(_ => _.Name == "d.ext").Which.Size.Should().Be(5626152);
        d.Files.Should().ContainSingle(_ => _.Name == "k").Which.Size.Should().Be(7214296);
        
        var e = a.Directories.Should().ContainSingle(_ => _.Name == "e").Which;
        e.Files.Should().ContainSingle(_ => _.Name == "i").Which.Size.Should().Be(584);

        e.TotalSize.Should().Be(584);
        a.TotalSize.Should().Be(94853);
        d.TotalSize.Should().Be(24933642);
        root.TotalSize.Should().Be(48381165);

        explorer.Path.FindDirectoriesWhere(_ => _.TotalSize <= 100000).Sum(_ => _.TotalSize).Should().Be(95437);
    }
    
    [Fact]
    public void Test2()
    {
        var explorer = new FileSystemExplorer(System.IO.File.ReadAllLines("Day07/answer.txt"));

        explorer.Path.FindDirectoriesWhere(_ => _.TotalSize <= 100000).Sum(_ => _.TotalSize).Should().Be(1501149);
    }
}