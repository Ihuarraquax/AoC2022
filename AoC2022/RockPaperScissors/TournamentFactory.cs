namespace AoC2022.RockPaperScissors;

public static class TournamentFactory
{
    public static Tournament InputPartOne(string fileName)
    {
        var lines = File.ReadLines(fileName);

        var rounds = lines.Select(line =>
        {
            var picks = line.Split(' ');
            return new Round(
                RockPaperScissorsParser.ParseShape(picks[0]), 
                RockPaperScissorsParser.ParseShape(picks[1]));
        });

        return new Tournament(rounds.ToArray());
    }
    
    public static Tournament InputPartTwo(string fileName)
    {
        var lines = File.ReadLines(fileName);

        var rounds = lines.Select(line =>
        {
            var picks = line.Split(' ');
            return new Round(
                RockPaperScissorsParser.ParseShape(picks[0]), 
                RockPaperScissorsParser.ParseGameResult(picks[1]));
        });

        return new Tournament(rounds.ToArray());
    }
}