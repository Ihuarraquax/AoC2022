namespace AoC2022.HandheldDevice;

public class Crt
{
    private List<char> list = new();
    private readonly int pixelsWide = 40;
    public string CurrentRowDisplay() => new(list.Skip(list.Count / pixelsWide * pixelsWide).ToArray());

    public void Render(bool isLit)
    {
        list.Add(isLit ? '#' : '.');
    }

    public string DisplayInLine() => new(list.ToArray());

    public void Print()
    {
        list
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / (pixelsWide))
            .Select(x => new string(x.Select(v => v.Value).ToArray()))
            .ToList().ForEach(Console.WriteLine);
    }
}