namespace AoC2022.MonkeyInTheMiddle;

public class Game
{
    public int Round { get; private set; } = 1;
    private readonly Monkey[] monkeys;

    public Game(params Monkey[] monkeys)
    {
        this.monkeys = monkeys;
    }

    public Game(int startingAfterRound, params Monkey[] monkeys)
    {
        Round = startingAfterRound;
        this.monkeys = monkeys;
    }


    public void PlayRound()
    {
        Round++;
        foreach (var monkey in monkeys)
        {
            while (monkey.HasMoreItemsToInspect())
            {
                monkey.TakeTurn();
            }
        }
    }

    public int GetLevelOfMonkeyBusiness() => monkeys.OrderByDescending(_ => _.InspectedItemsCount).Take(2)
        .Aggregate(1, (i, monkey) => i * monkey.InspectedItemsCount);
}