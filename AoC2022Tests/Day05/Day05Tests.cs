using AoC2022.CargoCrane;

namespace AoC2022Tests.Day05;

public class Day05Tests
{
    [Fact]
    public void Test1()
    {
        var stack1 = new Stack("Z", "N");
        var stack2 = new Stack("M", "C", "D");
        var stack3 = new Stack("P");
        
        var hold = new Hold(stack1, stack2, stack3);

        var crane = new CargoCrane(hold);

        stack1.Count.Should().Be(2);
        stack1.At(1).Should().Be("Z");
        stack1.At(2).Should().Be("N");
        stack1.Top.Should().Be("N");

        stack2.Count.Should().Be(3);
        stack2.At(1).Should().Be("M");
        stack2.At(2).Should().Be("C");
        stack2.At(3).Should().Be("D");
        stack2.Top.Should().Be("D");

        stack3.Count.Should().Be(1);
        stack3.At(1).Should().Be("P");
        stack3.Top.Should().Be("P");
        

        crane.ExecuteCommand("move 1 from 2 to 1");

        stack1.Count.Should().Be(3);
        stack1.At(1).Should().Be("Z");
        stack1.At(2).Should().Be("N");
        stack1.At(3).Should().Be("D");
        stack1.Top.Should().Be("D");

        stack2.Count.Should().Be(2);
        stack2.At(1).Should().Be("M");
        stack2.At(2).Should().Be("C");
        stack2.Top.Should().Be("C");

        stack3.Count.Should().Be(1);
        stack3.At(1).Should().Be("P");
        stack3.Top.Should().Be("P");

        hold.GetTopStackMessage().Should().Be("DCP");
        
        crane.ExecuteCommand("move 3 from 1 to 3");

        stack1.Count.Should().Be(0);
        
        stack2.Count.Should().Be(2);
        stack2.At(1).Should().Be("M");
        stack2.At(2).Should().Be("C");
        stack2.Top.Should().Be("C");
        
        stack3.Count.Should().Be(4);
        stack3.At(1).Should().Be("P");
        stack3.At(2).Should().Be("D");
        stack3.At(3).Should().Be("N");
        stack3.At(4).Should().Be("Z");
        stack3.Top.Should().Be("Z");
    }
    
    [Fact]
    public void Test2()
    {
        var (hold, commands) = DrawingParser.From("Day05/test.txt");
        
        var crane = new CargoCrane(hold);

        foreach (var command in commands)
        {
            crane.ExecuteCommand(command);
        }
        
        hold.At(1).At(1).Should().Be("C");
        hold.At(2).At(1).Should().Be("M");
        
        hold.At(3).At(1).Should().Be("P");
        hold.At(3).At(2).Should().Be("D");
        hold.At(3).At(3).Should().Be("N");
        hold.At(3).At(4).Should().Be("Z");

        hold.GetTopStackMessage().Should().Be("CMZ");
    }
    
    [Fact]
    public void Test3()
    {
        var (hold, commands) = DrawingParser.From("Day05/answer.txt");
        
        var crane = new CargoCrane(hold);

        foreach (var command in commands)
        {
            crane.ExecuteCommand(command);
        }

        hold.GetTopStackMessage().Should().Be("FWSHSPJWM");
    }
    
    [Fact]
    public void Test4()
    {
        var stack1 = new Stack("Z", "N");
        var stack2 = new Stack("M", "C", "D");
        var stack3 = new Stack("P");
        
        var hold = new Hold(stack1, stack2, stack3);

        var crane = new CargoCrane(hold, isMultipleMove: true);

        
        crane.ExecuteCommand("move 1 from 2 to 1");
        crane.ExecuteCommand("move 3 from 1 to 3");

        stack1.Count.Should().Be(0);
        
        stack2.Count.Should().Be(2);
        stack2.At(1).Should().Be("M");
        stack2.At(2).Should().Be("C");
        stack2.Top.Should().Be("C");
        
        stack3.Count.Should().Be(4);
        stack3.At(1).Should().Be("P");
        stack3.At(2).Should().Be("Z");
        stack3.At(3).Should().Be("N");
        stack3.At(4).Should().Be("D");
        stack3.Top.Should().Be("D");
    }
    
    [Fact]
    public void Test5()
    {
        var (hold, commands) = DrawingParser.From("Day05/answer.txt");
        
        var crane = new CargoCrane(hold, isMultipleMove: true);

        foreach (var command in commands)
        {
            crane.ExecuteCommand(command);
        }

        hold.GetTopStackMessage().Should().Be("PWPWHGFZS");
    }
}