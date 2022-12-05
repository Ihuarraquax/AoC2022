namespace AoC2022.Rucksacks;

public class Rucksack
{
    public string Left { get; }
    public string Right { get; }
    public string Content { get; }
    public Rucksack(string rucksackContent)
    {
        Left = rucksackContent.Substring(0, rucksackContent.Length / 2);
        Right = rucksackContent.Substring(rucksackContent.Length / 2);
        Content = rucksackContent;
    }

    public SharedItem GetSharedItem() => new(Left.First(leftItem => Right.Contains(leftItem)));
}