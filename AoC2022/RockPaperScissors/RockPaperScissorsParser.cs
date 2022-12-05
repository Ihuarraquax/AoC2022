using AoC2022.RockPaperScissors.Shapes;

namespace AoC2022.RockPaperScissors;

public static class RockPaperScissorsParser
{
    public static Shape ParseShape(string code) =>
        code switch
        {
            "A" => new Rock(),
            "B" => new Paper(),
            "C" => new Scissors(),
            "X" => new Rock(),
            "Y" => new Paper(),
            "Z" => new Scissors(),
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    
    public static Round.Result ParseGameResult(string code) =>
        code switch
        {
            "X" => Round.Result.Lose,
            "Y" => Round.Result.Draw,
            "Z" => Round.Result.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
}