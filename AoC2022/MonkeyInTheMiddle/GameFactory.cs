namespace AoC2022.MonkeyInTheMiddle;

public static class GameFactory
{
    public static Game From(IEnumerable<string> lines, bool relief = true)
    {
        var parsedMonkeys = new List<(Monkey monkey, int trueMonkey, int falseMonkey)>();

        foreach (var grouping in lines.Select((l, i) => new { l, i }).GroupBy(group => group.i / 7))
        {
            parsedMonkeys.Add(ParseMonkey(grouping.Select(_ => _.l).ToArray(), relief));
        }

        parsedMonkeys.ForEach(tuple =>
        {
            tuple.monkey.SetTrueMonkey(parsedMonkeys[tuple.trueMonkey].monkey);
            tuple.monkey.SetFalseMonkey(parsedMonkeys[tuple.falseMonkey].monkey);
        });

        return new Game(parsedMonkeys.Select(_ => _.monkey).ToArray());
    }

    private static (Monkey monkey, int trueMonkey, int falseMonkey) ParseMonkey(IReadOnlyList<string> lines,
        bool relief)
    {
        var items = ValueAfter(lines[1], "Starting items: ").Split(", ").Select(ulong.Parse);
        var operation = ValueAfter(lines[2], "new = ").Trim();
        var divideBy = int.Parse(ValueAfter(lines[3], "divisible by "));
        var trueNum = int.Parse(ValueAfter(lines[4], "If true: throw to monkey "));
        var falseNum = int.Parse(ValueAfter(lines[5], "If false: throw to monkey "));

        var monkey = new Monkey(items.ToArray(), new MonkeyOperation(operation), divideBy, relief);
        return (monkey, trueNum, falseNum);
    }

    private static string ValueAfter(string line, string text)
    {
        return line[(line.IndexOf(text, StringComparison.Ordinal) + text.Length)..];
    }
}