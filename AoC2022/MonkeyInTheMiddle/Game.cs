using System.Collections.Immutable;

namespace AoC2022.MonkeyInTheMiddle;

public class Game
{
    public int Round { get; private set; }
    private readonly Monkey[] monkeys;

    public IList<Monkey> Monkeys => monkeys.ToImmutableList();

    public Game(params Monkey[] monkeys)
    {
        this.monkeys = monkeys;
        Monkey.Equalizer = monkeys.Select(_ => _.TestDivisibleBy).Aggregate(1, (i, i1) => i * i1);
    }

    public Game(int startingAfterRound, params Monkey[] monkeys)
    {
        Round = startingAfterRound;
        this.monkeys = monkeys;

        Monkey.Equalizer = monkeys.Select(_ => _.TestDivisibleBy).Aggregate(1, (i, i1) => i * i1);
    }

    public void PlayRound(int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            PlayRound();
        }
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

    public ulong GetLevelOfMonkeyBusiness() => monkeys.OrderByDescending(_ => _.InspectedItemsCount).Take(2)
        .Aggregate((ulong)1, (i, monkey) => i * (ulong)monkey.InspectedItemsCount);
}