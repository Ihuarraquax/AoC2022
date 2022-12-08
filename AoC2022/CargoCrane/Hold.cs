namespace AoC2022.CargoCrane;

public class Hold
{
    private readonly Stack[] stacks;

    public Hold(params Stack[] stacks)
    {
        this.stacks = stacks;
    }

    public Stack At(int from)
        => stacks[from - 1];

    public string GetTopStackMessage() => string.Join(null, stacks.Select(_ => _.Top));
}