namespace AoC2022.Rucksacks;

public class GroupOfRucksacks
{
    public Rucksack[] Rucksacks { get; }

    public GroupOfRucksacks(Rucksack[] rucksacks)
    {
        if (rucksacks.Length != 3)
        {
            throw new InvalidOperationException("Group of rucksacks should be of size 3");
        }
        Rucksacks = rucksacks;
    }

    public SharedItem GetSharedItem() => 
        new(Rucksacks[0].Content.First(item => Rucksacks[1].Content.Contains(item) && Rucksacks[2].Content.Contains(item)));
}