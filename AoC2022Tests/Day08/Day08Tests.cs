using AoC2022.TreeHouse;

namespace AoC2022Tests.Day08;

public class Day08Tests
{
    [Fact]
    public void Test1()
    {
        var forest = ForestFactory.From(new[,]
        {
            { 3, 0, 3, 7, 3 },
            { 2, 5, 5, 1, 2 },
            { 6, 5, 3, 3, 2 },
            { 3, 3, 5, 4, 9 },
            { 3, 5, 3, 9, 0 }
        });

        // The top-left 5 is visible from the left and top. (It isn't visible from the right or bottom since other trees of height 5 are in the way.)
        forest.IsVisible(1, 1).Should().BeTrue();
        
        // The top-middle 5 is visible from the top and right.
        forest.IsVisible(1, 2).Should().BeTrue();
        
        // The top-right 1 is not visible from any direction; for it to be visible, there would need to only be trees of height 0 between it and an edge.
        forest.IsVisible(1, 3).Should().BeFalse();
        
        // The left-middle 5 is visible, but only from the right.
        forest.IsVisible(1, 2).Should().BeTrue();
        
        // The center 3 is not visible from any direction; for it to be visible, there would need to be only trees of at most height 2 between it and an edge.
        forest.IsVisible(2, 2).Should().BeFalse();
        
        // The right-middle 3 is visible from the right.
        forest.IsVisible(3, 2).Should().BeTrue();
        
        // In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
        forest.IsVisible(2, 3).Should().BeTrue();

        forest.ScenicScoreFromTop(forest.TreeAt(1, 2)).Should().Be(1);
        forest.ScenicScoreFromLeft(forest.TreeAt(1, 2)).Should().Be(1);
        forest.ScenicScoreFromRight(forest.TreeAt(1, 2)).Should().Be(2);
        forest.ScenicScoreFromBottom(forest.TreeAt(1, 2)).Should().Be(2);
        forest.GetScenicScore(1, 2).Should().Be(4);
        
        forest.ScenicScoreFromTop(forest.TreeAt(3, 2)).Should().Be(2);
        forest.ScenicScoreFromLeft(forest.TreeAt(3, 2)).Should().Be(2);
        forest.ScenicScoreFromRight(forest.TreeAt(3, 2)).Should().Be(2);
        forest.ScenicScoreFromBottom(forest.TreeAt(3, 2)).Should().Be(1);
        forest.GetScenicScore(3, 2).Should().Be(8);
        
        forest.GetHighestScenicScore().Should().Be(8);
    }
    
    [Fact]
    public void Test2()
    {
        var forest = ForestFactory.From(File.ReadLines("Day08/test.txt").ToList());

        // The top-left 5 is visible from the left and top. (It isn't visible from the right or bottom since other trees of height 5 are in the way.)
        forest.IsVisible(1, 1).Should().BeTrue();
        
        // The top-middle 5 is visible from the top and right.
        forest.IsVisible(1, 2).Should().BeTrue();
        
        // The top-right 1 is not visible from any direction; for it to be visible, there would need to only be trees of height 0 between it and an edge.
        forest.IsVisible(1, 3).Should().BeFalse();
        
        // The left-middle 5 is visible, but only from the right.
        forest.IsVisible(1, 2).Should().BeTrue();
        
        // The center 3 is not visible from any direction; for it to be visible, there would need to be only trees of at most height 2 between it and an edge.
        forest.IsVisible(2, 2).Should().BeFalse();
        
        // The right-middle 3 is visible from the right.
        forest.IsVisible(3, 2).Should().BeTrue();
        
        // In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
        forest.IsVisible(2, 3).Should().BeTrue();

        forest.GetVisibleTrees().Should().HaveCount(21);
    }
    
    [Fact]
    public void Test3()
    {
        var forest = ForestFactory.From(File.ReadLines("Day08/answer.txt").ToList());

        forest.GetVisibleTrees().Should().HaveCount(1546);
        forest.GetHighestScenicScore().Should().Be(519064);
    }
}