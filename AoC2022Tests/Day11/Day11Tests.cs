using AoC2022.MonkeyInTheMiddle;

namespace AoC2022Tests.Day11;

public class Day11Tests
{
    [Fact]
    public void Test1()
    {
        var monkey0 = new Monkey(new[] { 79, 98 }, new MonkeyOperation("old * 19"), 23);
        var monkey1 = new Monkey(new[] { 54, 65, 75, 74 }, new MonkeyOperation("old + 6"), 19);
        var monkey2 = new Monkey(new[] { 79, 60, 97 }, new MonkeyOperation("old * old"), 13);
        var monkey3 = new Monkey(new[] { 74 }, new MonkeyOperation("old + 3"), 17);

        monkey0.SetTrueMonkey(monkey2);
        monkey0.SetFalseMonkey(monkey3);

        monkey1.SetTrueMonkey(monkey2);
        monkey1.SetFalseMonkey(monkey0);

        monkey2.SetTrueMonkey(monkey1);
        monkey2.SetFalseMonkey(monkey3);

        monkey3.SetTrueMonkey(monkey0);
        monkey3.SetFalseMonkey(monkey1);

        // monke 0
        monkey0.InspectingItem.WorryLevel.Should().Be(79);
        monkey0.CalculateWorryLevel();
        monkey0.InspectingItem.WorryLevel.Should().Be(1501);
        monkey0.GetBored();
        monkey0.InspectingItem.WorryLevel.Should().Be(500);
        monkey0.ThrowItemToMonkey();

        monkey3.LastItemToInspect.WorryLevel.Should().Be(500);


        monkey0.InspectingItem.WorryLevel.Should().Be(98);
        monkey0.CalculateWorryLevel();
        monkey0.InspectingItem.WorryLevel.Should().Be(1862);
        monkey0.GetBored();
        monkey0.InspectingItem.WorryLevel.Should().Be(620);
        monkey0.ThrowItemToMonkey();

        monkey3.LastItemToInspect.WorryLevel.Should().Be(620);

        // monke 1
        monkey1.InspectingItem.WorryLevel.Should().Be(54);
        monkey1.CalculateWorryLevel();
        monkey1.InspectingItem.WorryLevel.Should().Be(60);
        monkey1.GetBored();
        monkey1.InspectingItem.WorryLevel.Should().Be(20);
        monkey1.ThrowItemToMonkey();

        monkey0.LastItemToInspect.WorryLevel.Should().Be(20);


        monkey1.InspectingItem.WorryLevel.Should().Be(65);
        monkey1.CalculateWorryLevel();
        monkey1.InspectingItem.WorryLevel.Should().Be(71);
        monkey1.GetBored();
        monkey1.InspectingItem.WorryLevel.Should().Be(23);
        monkey1.ThrowItemToMonkey();

        monkey0.LastItemToInspect.WorryLevel.Should().Be(23);

        monkey1.InspectingItem.WorryLevel.Should().Be(75);
        monkey1.CalculateWorryLevel();
        monkey1.InspectingItem.WorryLevel.Should().Be(81);
        monkey1.GetBored();
        monkey1.InspectingItem.WorryLevel.Should().Be(27);
        monkey1.ThrowItemToMonkey();

        monkey0.LastItemToInspect.WorryLevel.Should().Be(27);


        monkey1.InspectingItem.WorryLevel.Should().Be(74);
        monkey1.CalculateWorryLevel();
        monkey1.InspectingItem.WorryLevel.Should().Be(80);
        monkey1.GetBored();
        monkey1.InspectingItem.WorryLevel.Should().Be(26);
        monkey1.ThrowItemToMonkey();

        monkey0.LastItemToInspect.WorryLevel.Should().Be(26);

        // monke 2
        monkey2.InspectingItem.WorryLevel.Should().Be(79);
        monkey2.CalculateWorryLevel();
        monkey2.InspectingItem.WorryLevel.Should().Be(6241);
        monkey2.GetBored();
        monkey2.InspectingItem.WorryLevel.Should().Be(2080);
        monkey2.ThrowItemToMonkey();

        monkey1.LastItemToInspect.WorryLevel.Should().Be(2080);


        monkey2.InspectingItem.WorryLevel.Should().Be(60);
        monkey2.CalculateWorryLevel();
        monkey2.InspectingItem.WorryLevel.Should().Be(3600);
        monkey2.GetBored();
        monkey2.InspectingItem.WorryLevel.Should().Be(1200);
        monkey2.ThrowItemToMonkey();

        monkey3.LastItemToInspect.WorryLevel.Should().Be(1200);


        monkey2.InspectingItem.WorryLevel.Should().Be(97);
        monkey2.CalculateWorryLevel();
        monkey2.InspectingItem.WorryLevel.Should().Be(9409);
        monkey2.GetBored();
        monkey2.InspectingItem.WorryLevel.Should().Be(3136);
        monkey2.ThrowItemToMonkey();

        monkey3.LastItemToInspect.WorryLevel.Should().Be(3136);

        // monke 3
        monkey3.InspectingItem.WorryLevel.Should().Be(74);
        monkey3.CalculateWorryLevel();
        monkey3.InspectingItem.WorryLevel.Should().Be(77);
        monkey3.GetBored();
        monkey3.InspectingItem.WorryLevel.Should().Be(25);
        monkey3.ThrowItemToMonkey();

        monkey1.LastItemToInspect.WorryLevel.Should().Be(25);


        monkey3.InspectingItem.WorryLevel.Should().Be(500);
        monkey3.CalculateWorryLevel();
        monkey3.InspectingItem.WorryLevel.Should().Be(503);
        monkey3.GetBored();
        monkey3.InspectingItem.WorryLevel.Should().Be(167);
        monkey3.ThrowItemToMonkey();

        monkey1.LastItemToInspect.WorryLevel.Should().Be(167);


        monkey3.InspectingItem.WorryLevel.Should().Be(620);
        monkey3.CalculateWorryLevel();
        monkey3.InspectingItem.WorryLevel.Should().Be(623);
        monkey3.GetBored();
        monkey3.InspectingItem.WorryLevel.Should().Be(207);
        monkey3.ThrowItemToMonkey();

        monkey1.LastItemToInspect.WorryLevel.Should().Be(207);


        monkey3.InspectingItem.WorryLevel.Should().Be(1200);
        monkey3.CalculateWorryLevel();
        monkey3.InspectingItem.WorryLevel.Should().Be(1203);
        monkey3.GetBored();
        monkey3.InspectingItem.WorryLevel.Should().Be(401);
        monkey3.ThrowItemToMonkey();

        monkey1.LastItemToInspect.WorryLevel.Should().Be(401);


        monkey3.InspectingItem.WorryLevel.Should().Be(3136);
        monkey3.CalculateWorryLevel();
        monkey3.InspectingItem.WorryLevel.Should().Be(3139);
        monkey3.GetBored();
        monkey3.InspectingItem.WorryLevel.Should().Be(1046);
        monkey3.ThrowItemToMonkey();

        monkey1.LastItemToInspect.WorryLevel.Should().Be(1046);

        monkey0.Items.Should().Equal(20, 23, 27, 26);
        monkey1.Items.Should().Equal(2080, 25, 167, 207, 401, 1046);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();

        var game = new Game(1, monkey0, monkey1, monkey2, monkey3);

        game.PlayRound();
        monkey0.Items.Should().Equal(695, 10, 71, 135, 350);
        monkey1.Items.Should().Equal(43, 49, 58, 55, 362);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(16, 18, 21, 20, 122);
        monkey1.Items.Should().Equal(1468, 22, 150, 286, 739);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(491, 9, 52, 97, 248, 34);
        monkey1.Items.Should().Equal(39, 45, 43, 258);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(15, 17, 16, 88, 1037);
        monkey1.Items.Should().Equal(20, 110, 205, 524, 72);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(8, 70, 176, 26, 34);
        monkey1.Items.Should().Equal(481, 32, 36, 186, 2190);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(162, 12, 14, 64, 732, 17);
        monkey1.Items.Should().Equal(148, 372, 55, 72);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(51, 126, 20, 26, 136);
        monkey1.Items.Should().Equal(343, 26, 30, 1546, 36);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(116, 10, 12, 517, 14);
        monkey1.Items.Should().Equal(108, 267, 43, 55, 288);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        monkey0.Items.Should().Equal(91, 16, 20, 98);
        monkey1.Items.Should().Equal(481, 245, 22, 26, 1092, 30);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        game.PlayRound();
        game.PlayRound();
        game.PlayRound();
        game.PlayRound();
        monkey0.Items.Should().Equal(83, 44, 8, 184, 9, 20, 26, 102);
        monkey1.Items.Should().Equal(110, 36);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();
        
        game.PlayRound();
        game.PlayRound();
        game.PlayRound();
        game.PlayRound();
        game.PlayRound();
        monkey0.Items.Should().Equal(10, 12, 14, 26, 34);
        monkey1.Items.Should().Equal(245, 93, 53, 199, 115);
        monkey2.Items.Should().Equal();
        monkey3.Items.Should().Equal();

        game.Round.Should().Be(20);
        monkey0.InspectedItemsCount.Should().Be(101);
        monkey1.InspectedItemsCount.Should().Be(95);
        monkey2.InspectedItemsCount.Should().Be(7);
        monkey3.InspectedItemsCount.Should().Be(105);
        
        game.GetLevelOfMonkeyBusiness().Should().Be(10605);
    }
}