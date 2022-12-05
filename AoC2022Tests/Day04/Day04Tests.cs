using AoC2022;
using AoC2022.SectionAssigments;

namespace AoC2022Tests.Day04;

public class Day04Tests
{
    [Theory]
    [InlineData("2-4", "6-8", false, false)]
    [InlineData("2-3", "4-5", false, false)]
    [InlineData("5-7", "7-9", false, true)]
    [InlineData("2-8", "3-7", true, true)]
    [InlineData("6-6", "4-6", true, true)]
    [InlineData("2-6", "4-8", false, true)]
    public void Test1(string firstElfAssigment, string secondElfAssigment, bool oneSectionFullyContainsOther, bool overlapAtAll)
    {
        var sectionAssigment = new SectionAssigmentPair(firstElfAssigment, secondElfAssigment);

        sectionAssigment.OneSectionFullyContainsOther.Should().Be(oneSectionFullyContainsOther);
        sectionAssigment.SectionsOverlapAtAll.Should().Be(overlapAtAll);
    }

    [Fact]
    public void Test2()
    {
        ListOfSectionAssigmentPairs list = ListOfSectionAssigmentPairs.From("Day04/test.txt");
        list.GetSumOfSectionAssigmentPairWhereOneSectionFullyContainsOther().Should().Be(2);
    }
    
    [Fact]
    public void Test3()
    {
        ListOfSectionAssigmentPairs list = ListOfSectionAssigmentPairs.From("Day04/answer.txt");
        var answer = list.GetSumOfSectionAssigmentPairWhereOneSectionFullyContainsOther();
        answer.Should().Be(532);
    }
    
    [Fact]
    public void Test4()
    {
        ListOfSectionAssigmentPairs list = ListOfSectionAssigmentPairs.From("Day04/test.txt");
        list.GetSumOfSectionAssigmentPairWhereOneSectionsOverlapAtAll().Should().Be(4);
    }
    
    [Fact]
    public void Test5()
    {
        ListOfSectionAssigmentPairs list = ListOfSectionAssigmentPairs.From("Day04/answer.txt");
        var answer = list.GetSumOfSectionAssigmentPairWhereOneSectionsOverlapAtAll();
        answer.Should().Be(854);
    }
}