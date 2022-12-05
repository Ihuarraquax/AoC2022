using AoC2022.RockPaperScissors;
using FluentAssertions;

namespace AoC2022Tests.Day02;

public class Day02Tests
{
    [Fact]
    public void Test1()
    {
        var round = new Round(
            RockPaperScissorsParser.ParseShape("A"),
            RockPaperScissorsParser.ParseShape("Y"));
        var round1 = new Round(
            RockPaperScissorsParser.ParseShape("B"),
            RockPaperScissorsParser.ParseShape("X"));
        var round2 = new Round(
            RockPaperScissorsParser.ParseShape("C"),
            RockPaperScissorsParser.ParseShape("Z"));

        var tournament = new Tournament(round, round1, round2);

        tournament.MyScore(1).Should().Be(8);
        tournament.MyScore(2).Should().Be(1);
        tournament.MyScore(3).Should().Be(6);

        tournament.MyTotalScore().Should().Be(15);

        tournament.OpponentScore(1).Should().Be(1);
        tournament.OpponentScore(2).Should().Be(8);
        tournament.OpponentScore(3).Should().Be(6);

        tournament.OpponentTotalScore().Should().Be(15);
    }

    [Fact]
    public void Test2()
    {
        var tournament = TournamentFactory.InputPartOne("Day02/test.txt");

        tournament.MyScore(1).Should().Be(8);
        tournament.MyScore(2).Should().Be(1);
        tournament.MyScore(3).Should().Be(6);

        tournament.MyTotalScore().Should().Be(15);

        tournament.OpponentScore(1).Should().Be(1);
        tournament.OpponentScore(2).Should().Be(8);
        tournament.OpponentScore(3).Should().Be(6);

        tournament.OpponentTotalScore().Should().Be(15);
    }

    [Fact]
    public void Test3()
    {
        var round = new Round(
            RockPaperScissorsParser.ParseShape("A"),
            RockPaperScissorsParser.ParseGameResult("Y"));
        var round1 = new Round(
            RockPaperScissorsParser.ParseShape("B"),
            RockPaperScissorsParser.ParseGameResult("X"));
        var round2 = new Round(
            RockPaperScissorsParser.ParseShape("C"),
            RockPaperScissorsParser.ParseGameResult("Z"));
        
        var tournament = new Tournament(round, round1, round2);

        tournament.MyScore(1).Should().Be(4);
        tournament.MyScore(2).Should().Be(1);
        tournament.MyScore(3).Should().Be(7);

        tournament.MyTotalScore().Should().Be(12);

        tournament.OpponentScore(1).Should().Be(4);
        tournament.OpponentScore(2).Should().Be(8);
        tournament.OpponentScore(3).Should().Be(3);

        tournament.OpponentTotalScore().Should().Be(15);
    }
    
    [Fact]
    public void Test4()
    {
        var tournament = TournamentFactory.InputPartTwo("Day02/test.txt");

        tournament.MyScore(1).Should().Be(4);
        tournament.MyScore(2).Should().Be(1);
        tournament.MyScore(3).Should().Be(7);

        tournament.MyTotalScore().Should().Be(12);

        tournament.OpponentScore(1).Should().Be(4);
        tournament.OpponentScore(2).Should().Be(8);
        tournament.OpponentScore(3).Should().Be(3);

        tournament.OpponentTotalScore().Should().Be(15);
    }
    
    [Fact]
    public void AnswerPartTwo()
    {
        var tournament = TournamentFactory.InputPartTwo("Day02/answer.txt");

        var result = tournament.MyTotalScore();
    }
}