namespace AoC2022.RockPaperScissors.Shapes;

internal record Rock : Shape
{
    public override int Points => 1;

    public override bool Defeats(Shape shape) =>
        shape switch
        {
            Paper => false,
            Scissors => true
        };

    public override Shape LosesTo()
        => new Paper();
    
    public override Shape WinsWith()
        => new Scissors();
}