using AoC2022.Rope;

namespace AoC2022Tests.Day09;

public class Day09Tests
{
    [Fact]
    public void Test1()
    {
        var rope = new Rope("T");

        rope.Head.X.Should().Be(0);
        rope.Head.Y.Should().Be(0);

        rope.Tail.X.Should().Be(0);
        rope.Tail.Y.Should().Be(0);


        rope.MoveRight(4);

        rope.Head.X.Should().Be(4);
        rope.Head.Y.Should().Be(0);

        rope.Tail.X.Should().Be(3);
        rope.Tail.Y.Should().Be(0);


        rope.MoveUp(4);

        rope.Head.X.Should().Be(4);
        rope.Head.Y.Should().Be(4);

        rope.Tail.X.Should().Be(4);
        rope.Tail.Y.Should().Be(3);


        rope.MoveLeft(3);

        rope.Head.X.Should().Be(1);
        rope.Head.Y.Should().Be(4);

        rope.Tail.X.Should().Be(2);
        rope.Tail.Y.Should().Be(4);


        rope.MoveDown(1);

        rope.Head.X.Should().Be(1);
        rope.Head.Y.Should().Be(3);

        rope.Tail.X.Should().Be(2);
        rope.Tail.Y.Should().Be(4);


        rope.MoveRight(4);

        rope.Head.X.Should().Be(5);
        rope.Head.Y.Should().Be(3);

        rope.Tail.X.Should().Be(4);
        rope.Tail.Y.Should().Be(3);


        rope.MoveDown(1);

        rope.Head.X.Should().Be(5);
        rope.Head.Y.Should().Be(2);

        rope.Tail.X.Should().Be(4);
        rope.Tail.Y.Should().Be(3);


        rope.MoveLeft(5);

        rope.Head.X.Should().Be(0);
        rope.Head.Y.Should().Be(2);

        rope.Tail.X.Should().Be(1);
        rope.Tail.Y.Should().Be(2);


        rope.MoveRight(2);

        rope.Head.X.Should().Be(2);
        rope.Head.Y.Should().Be(2);

        rope.Tail.X.Should().Be(1);
        rope.Tail.Y.Should().Be(2);

        rope.Tail.PositionsVisited.Count.Should().Be(13);
    }
    
    [Fact]
    public void Test2()
    {
        var rope = RopeFactory.HeadTailRopeFrom(File.ReadLines("Day09/test.txt").ToList());
        
        rope.Head.X.Should().Be(2);
        rope.Head.Y.Should().Be(2);

        rope.Tail.X.Should().Be(1);
        rope.Tail.Y.Should().Be(2);

        rope.Tail.PositionsVisited.Count.Should().Be(13);
    }
    
    [Fact]
    public void Test3()
    {
        var rope = RopeFactory.HeadTailRopeFrom(File.ReadLines("Day09/answer.txt").ToList());

        rope.Tail.PositionsVisited.Count.Should().Be(6486);
    }
    
    [Fact]
    public void Test4()
    {
        var rope = RopeFactory.TenKnotsRopeFrom(File.ReadLines("Day09/test.txt").ToList());

        rope.Tail.PositionsVisited.Count.Should().Be(1);
    }
    
    [Fact]
    public void Test5()
    {
        var rope = RopeFactory.TenKnotsRopeFrom(File.ReadLines("Day09/answer.txt").ToList());

        rope.Tail.PositionsVisited.Count.Should().Be(2678);
    }
}