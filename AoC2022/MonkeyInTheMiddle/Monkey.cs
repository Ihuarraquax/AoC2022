namespace AoC2022.MonkeyInTheMiddle;

public class Monkey
{
    private readonly MonkeyOperation operation;
    private readonly int testDivisibleBy;
    private readonly Queue<Item> queue;
    private Monkey trueMonkey;
    private Monkey falseMonkey;

    private Item? NextItem => queue.TryDequeue(out var item) ? item : null;
    public Item? InspectingItem { get; set; }
    public Item LastItemToInspect => queue.Last();
    public int[] Items => queue.Select(_ => _.WorryLevel).ToArray();
    public int InspectedItemsCount { get; private set; }

    public Monkey(int[] startingItems, MonkeyOperation operation, int testDivisibleBy)
    {
        this.operation = operation;
        this.testDivisibleBy = testDivisibleBy;
        queue = new Queue<Item>(startingItems.Select(worryLevel => new Item(worryLevel)));
        InspectItem();
    }

    private void InspectItem()
    {
        if (InspectingItem is not null) return;
        InspectingItem = NextItem;
    }

    private void ItemIsThrownAway()
    {
        InspectingItem = null;
        InspectedItemsCount++;
    }

    public bool HasMoreItemsToInspect() => InspectingItem is not null || queue.Count > 0;

    public void SetTrueMonkey(Monkey monkey) => trueMonkey = monkey;
    public void SetFalseMonkey(Monkey monkey) => falseMonkey = monkey;

    public void CalculateWorryLevel()
    {
        InspectingItem.WorryLevel = operation.CalculateNew(InspectingItem.WorryLevel);
    }

    public void GetBored()
    {
        InspectingItem.WorryLevel /= 3;
    }

    public void ThrowItemToMonkey()
    {
        var monkeyToThrow = ChooseTargetMonkey();

        monkeyToThrow.Catch(InspectingItem);
        ItemIsThrownAway();
        InspectItem();
    }

    private void Catch(Item item) =>
        queue.Enqueue(item);

    private Monkey ChooseTargetMonkey()
    {
        return InspectingItem.WorryLevel % testDivisibleBy == 0 ? trueMonkey : falseMonkey;
    }

    public void TakeTurn()
    {
        InspectItem();
        CalculateWorryLevel();
        GetBored();
        ThrowItemToMonkey();
    }
}