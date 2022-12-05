namespace AoC2022.RockPaperScissors;

public abstract record Shape
{
    public abstract int Points { get; }

    public abstract bool Defeats(Shape shape);
    
    public abstract Shape LosesTo();
    
    public abstract Shape WinsWith();
}