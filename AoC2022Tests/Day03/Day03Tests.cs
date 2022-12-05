using AoC2022;
using AoC2022.Rucksacks;

namespace AoC2022Tests.Day03;

public class Day03Tests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp","vJrwpWtwJgWr","hcsFMMfFFhFp", "p", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL","jqHRNqRjqzjGDLGL","rsFMfFZSrLrFZsSL", "L", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg","PmmdzqPrV","vPwwTWBwg", "P", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn","wMqvLMZHhHMvwLH","jbvcjnnSBnvTQFn", "v", 22)]
    [InlineData("ttgJtRGJQctTZtZT","ttgJtRGJ","QctTZtZT", "t", 20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw","CrZsJsPPZsGz","wwsLwLmpwMDw", "s", 19)]
    public void Test1(string rucksackContentInput,string left, string right, string letterThatAppearsInBoth, int priority)
    {
        var rucksackContent = new Rucksack(rucksackContentInput);
        rucksackContent.Left.Length.Should().Be(rucksackContent.Right.Length);
        rucksackContent.Left.Should().Be(left);
        rucksackContent.Right.Should().Be(right);

        var sharedItem = rucksackContent.GetSharedItem();
        
        sharedItem.ValueString.Should().Be(letterThatAppearsInBoth);
        sharedItem.Priority.Should().Be(priority);
    }

    [Fact]
    public void Test2()
    {
        var list = ListOfRucksacks.From("Day03/test.txt");

        list.SumOfPriorities().Should().Be(157);
    }
    
    [Fact]
    public void Test3()
    {
        var list = ListOfRucksacks.From("Day03/answer.txt");

        var answer = list.SumOfPriorities();
    }
    
    [Fact]
    public void Test4()
    {
        List<GroupOfRucksacks> list = ListOfRucksacks.GroupsOfThreeFrom("Day03/test.txt");
        list[0].GetSharedItem().Priority.Should().Be(18);
        list[1].GetSharedItem().Priority.Should().Be(52);
        
        var answer = list.Sum(_ => _.GetSharedItem().Priority);
        answer.Should().Be(70);
    }
    
    [Fact]
    public void Test5()
    {
        List<GroupOfRucksacks> list = ListOfRucksacks.GroupsOfThreeFrom("Day03/answer.txt");
        
        var answer = list.Sum(_ => _.GetSharedItem().Priority);
    }
}