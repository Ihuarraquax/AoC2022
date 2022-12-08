namespace AoC2022.SectionAssigment;

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