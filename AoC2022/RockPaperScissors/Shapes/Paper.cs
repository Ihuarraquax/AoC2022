namespace AoC2022.RockPaperScissors.Shapes;

internal record Paper : Shape
{
    public override int Points => 2;

    public override bool Defeats(Shape shape) =>
        shape switch
        {
            Rock => true,
            Scissors => false
        };

    public override Shape LosesTo()
        => new Scissors();
    
    public override Shape WinsWith()
        => new Rock();
}