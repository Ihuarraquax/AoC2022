namespace AoC2022.HandheldDevice;

public class Sprite
{
    public int Position { get; set; } = 1;

    public bool IsIn(int position) => position >= Position - 1 && position <= Position + 1;
}