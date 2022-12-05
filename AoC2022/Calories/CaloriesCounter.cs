namespace AoC2022.Calories;

public class CaloriesCounter
{
    public IList<Elf> Elves { get; set; }
    
    public void Calculate(string fileName)
    {
        var lines = File.ReadLines(fileName);

        Elves = new List<Elf>();
        Elves.Add(new Elf());
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                Elves.Add(new Elf());
                continue;
            }

            Elves.Last().Calories += int.Parse(line);
        }
    }

    public (int index, int calories) GetResult()
    {
        var index = Elves.IndexOf(Elves.MaxBy(_ => _.Calories));
        var calories = Elves[index].Calories;
        return (index, calories);
    }
    
    public IList<Elf> GetTop3() => Elves.OrderByDescending(_ => _.Calories).Take(3).ToList();
}