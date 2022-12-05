namespace AoC2022.RockPaperScissors;

public class Tournament
{
    private readonly Round[] rounds;

    public Tournament(params Round[] rounds)
    {
        this.rounds = rounds;
    }

    public int MyScore(int round) => rounds[round - 1].Player2Score;
    public int MyTotalScore() => rounds.Sum(_ => _.Player2Score);
    public int OpponentScore(int round) => rounds[round - 1].Player1Score;
    public int OpponentTotalScore() => rounds.Sum(_ => _.Player1Score);
}