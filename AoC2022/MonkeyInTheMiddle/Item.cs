namespace AoC2022.MonkeyInTheMiddle;

public class Item
{
    public ulong WorryLevel { get; set; }

    public Item(ulong worryLevel)
    {
        WorryLevel = worryLevel;
    }
}