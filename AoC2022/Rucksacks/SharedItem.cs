namespace AoC2022.Rucksacks;

public class SharedItem
{
    public string ValueString => Value.ToString();
    public char Value { get; }
    
    public int Priority { get; }

    public SharedItem(char value)
    {
        Value = value;
        Priority = char.IsUpper(value) ? value - 64 + 26 : value - 96 ;
    }
}