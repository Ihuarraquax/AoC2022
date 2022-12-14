namespace AoC2022.MonkeyInTheMiddle;

public class Monkey
{
    public static int Equalizer;

    private readonly MonkeyOperation operation;
    public readonly int TestDivisibleBy;
    private readonly bool relief;
    private readonly Queue<Item> queue;
    private Monkey trueMonkey;
    private Monkey falseMonkey;

    private Item NextItem => queue.Dequeue();
    public Item? InspectingItem { get; set; }
    public Item LastItemToInspect => queue.Last();
    public ulong[] Items => queue.Select(_ => _.WorryLevel).ToArray();
    public int InspectedItemsCount { get; private set; }

    public Monkey(ulong[] startingItems, MonkeyOperation operation, int testDivisibleBy, bool relief = true)
    {
        this.operation = operation;
        this.TestDivisibleBy = testDivisibleBy;
        this.relief = relief;
        queue = new Queue<Item>(startingItems.Select(worryLevel => new Item(worryLevel)));
    }

    public void InspectItem()
    {
        InspectingItem = NextItem;
        InspectedItemsCount++;
    }

    public bool HasMoreItemsToInspect() => queue.Count > 0;

    public void SetTrueMonkey(Monkey monkey) => trueMonkey = monkey;
    public void SetFalseMonkey(Monkey monkey) => falseMonkey = monkey;

    public void CalculateWorryLevel()
    {
        if (relief)
        {
            InspectingItem.WorryLevel = operation.CalculateNew(InspectingItem.WorryLevel);
        }
        else
        {
            InspectingItem.WorryLevel = operation.CalculateNew(InspectingItem.WorryLevel) % (ulong)Equalizer;
        }
    }

    public void GetBored()
    {
        InspectingItem.WorryLevel = InspectingItem.WorryLevel /= 3;
    }

    public void ThrowItemToMonkey()
    {
        var monkeyToThrow = ChooseTargetMonkey();

        monkeyToThrow.Catch(InspectingItem);
    }

    private void Catch(Item item) =>
        queue.Enqueue(item);

    private Monkey ChooseTargetMonkey()
    {
        return InspectingItem.WorryLevel % (ulong)TestDivisibleBy == 0 ? trueMonkey : falseMonkey;
    }

    public void TakeTurn()
    {
        InspectItem();
        CalculateWorryLevel();

        if (relief)
        {
            GetBored();
        }

        ThrowItemToMonkey();
    }
}