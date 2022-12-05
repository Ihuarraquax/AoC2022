namespace AoC2022.SectionAssigment;

public class ListOfSectionAssigmentPairs
{
    private readonly SectionAssigmentPair[] sections;

    private ListOfSectionAssigmentPairs(params SectionAssigmentPair[] sections)
    {
        this.sections = sections;
    }

    public int GetSumOfSectionAssigmentPairWhereOneSectionFullyContainsOther() =>
        sections.Count(_ => _.OneSectionFullyContainsOther);
    
    public int GetSumOfSectionAssigmentPairWhereOneSectionsOverlapAtAll() =>
        sections.Count(_ => _.SectionsOverlapAtAll);

    public static ListOfSectionAssigmentPairs From(string file)
    {
        var lines = File.ReadLines(file);

        return new ListOfSectionAssigmentPairs(lines.ToList().Select(line =>
        {
            var splitted = line.Split(',');
            return new SectionAssigmentPair(splitted[0], splitted[1]);
        }).ToArray());
    }
}