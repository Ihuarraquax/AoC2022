namespace AoC2022.SectionAssigment;

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