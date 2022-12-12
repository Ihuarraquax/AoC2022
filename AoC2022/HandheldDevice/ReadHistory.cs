namespace AoC2022.HandheldDevice;

public class ReadHistory
{
    private readonly List<int> values = new();

    public void SaveRead(int registryValue)
    {
        values.Add(registryValue);
    }

    public int At(int cycleNumber)
    {
        return values[cycleNumber - 1];
    }
}