namespace AoC2022.RockPaperScissors.Shapes;

internal record Scissors : Shape
{
    public override int Points => 3;

    public override bool Defeats(Shape shape) =>
        shape switch
        {
            Rock => false,
            Paper => true
        };

    public override Shape LosesTo()
        => new Rock();

    public override Shape WinsWith()
        => new Paper();
}