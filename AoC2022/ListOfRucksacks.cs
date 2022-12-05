namespace AoC2022;

public class ListOfRucksacks
{
    public List<Rucksack> Rucksacks { get; init; }

    public static ListOfRucksacks From(string fileName)
    {
        var lines = File.ReadLines(fileName);

        return new ListOfRucksacks()
        {
            Rucksacks = lines.Select(line => new Rucksack(line)).ToList()
        };
    }

    public int SumOfPriorities()
    {
        return Rucksacks.Sum(_ => _.GetSharedItem().Priority);
    }

    public static List<GroupOfRucksacks> GroupsOfThreeFrom(string fileName)
    {
        var lines = File.ReadLines(fileName);

        return lines.Select((_, i) => new { Rucksack = new Rucksack(_), i }).GroupBy(_ => _.i / 3)
            .Select(_ => new GroupOfRucksacks(_.Select(_ => _.Rucksack).ToArray())).ToList();
    }
}