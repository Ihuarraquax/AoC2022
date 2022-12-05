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

public class AssigmentSections
{
    public AssigmentSections(AssigmentRange range)
    {
        Sections = Enumerable.Range(range.Start, range.End + 1 - range.Start);
    }

    private IEnumerable<int> Sections { get; }

    public bool FullyContains(AssigmentSections otherSection) => 
        Sections.Except(otherSection.Sections).Any() is false;

    public bool OverlapsWith(AssigmentSections otherSection) => 
        Sections.Any(otherSection.Sections.Contains);
}

public class SectionAssigmentPair
{
    private readonly AssigmentSections firstSections;
    private readonly AssigmentSections secondSections;

    public SectionAssigmentPair(string firstElfAssigment, string secondElfAssigment)
    {
        var firstRange = new AssigmentRange(firstElfAssigment);
        var secondRange = new AssigmentRange(secondElfAssigment);

        firstSections = new AssigmentSections(firstRange);
        secondSections = new AssigmentSections(secondRange);
    }

    public bool OneSectionFullyContainsOther => firstSections.FullyContains(secondSections) ||
                                                secondSections.FullyContains(firstSections);

    public bool SectionsOverlapAtAll => firstSections.OverlapsWith(secondSections);
}