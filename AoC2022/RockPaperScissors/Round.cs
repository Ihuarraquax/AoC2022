namespace AoC2022.RockPaperScissors;

public class Round
{
    public int Player1Score { get; }
    public int Player2Score { get; }

    public Round(Shape player1Pick, Shape player2Pick)
    {
        var (p1Score, p2Score) = GetResultOfGame(player1Pick, player2Pick);

        Player1Score = p1Score;
        Player2Score = p2Score;
    }
    
    public Round(Shape player1Pick, Result resultForPlayer2)
    {
        var (p1Score, p2Score) = GetResultOfGame(player1Pick, resultForPlayer2 switch
        {
            Result.Win => player1Pick.LosesTo(),
            Result.Lose => player1Pick.WinsWith(),
            Result.Draw => player1Pick,
            _ => throw new ArgumentOutOfRangeException(nameof(resultForPlayer2), resultForPlayer2, null)
        });

        Player1Score = p1Score;
        Player2Score = p2Score;
    }

    private (int, int) GetResultOfGame(Shape p1, Shape p2)
    {
        if (p1 == p2)
            return (3 + p1.Points, 3 + p2.Points);

        if (p1.Defeats(p2))
            return (6 + p1.Points, 0 + p2.Points);

        return (0 + p1.Points, 6 + p2.Points);
    }

    public enum Result
    {
        Win, Lose, Draw
    }
}