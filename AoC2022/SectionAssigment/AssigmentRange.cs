namespace AoC2022.SectionAssigment;

public class AssigmentRange
{
    public int Start { get; }
    public int End { get; }

    public AssigmentRange(string range)
    {
        var rangeArray = range.Split("-").Select(int.Parse).ToArray();
        Start = rangeArray[0];
        End = rangeArray[1];
    }
}