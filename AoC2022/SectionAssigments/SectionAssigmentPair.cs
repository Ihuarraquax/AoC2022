namespace AoC2022.SectionAssigments;

public class SectionAssigmentPair
{

    public IEnumerable<int> FirstSections { get; }
    public IEnumerable<int> SecondSection { get; }
    public int[] firstRange { get; }
    public int[] secondRange { get; }


    public SectionAssigmentPair(string firstElfAssigment, string secondElfAssigment)
    {
        firstRange = firstElfAssigment.Split("-").Select(int.Parse).ToArray();
        secondRange = secondElfAssigment.Split("-").Select(int.Parse).ToArray();

        FirstSections = Enumerable.Range(firstRange[0], firstRange[1] + 1 - firstRange[0]);
        SecondSection = Enumerable.Range(secondRange[0], secondRange[1] + 1 - secondRange[0]);
    }
    
    public bool OneSectionFullyContainsOther => FirstSections.Except(SecondSection).Any() is false ||
                                                SecondSection.Except(FirstSections).Any() is false;

    public bool SectionsOverlapAtAll => FirstSections.Any(SecondSection.Contains);
}