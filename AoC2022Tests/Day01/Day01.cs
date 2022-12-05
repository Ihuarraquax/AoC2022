using AoC2022;

namespace AoC2022Tests.Day01;

public class Day01Tests
{
    [Fact]
    public void Test1()
    {
        var fileName = "Day01/test.txt";
        
        var caloriesCounter = new CaloriesCounter();
        caloriesCounter.Calculate(fileName);
        
        
        Assert.Equal(6000,caloriesCounter.Elves[0].Calories );
        Assert.Equal(4000,caloriesCounter.Elves[1].Calories );
        Assert.Equal(11000,caloriesCounter.Elves[2].Calories );
        Assert.Equal(24000, caloriesCounter.Elves[3].Calories );
        Assert.Equal(10000, caloriesCounter.Elves[4].Calories );

        var (index, calories) = caloriesCounter.GetResult();
        Assert.Equal(3, index);
        Assert.Equal(24000, calories);

        var top3 = caloriesCounter.GetTop3();
        
        Assert.Equal(24000, top3[0].Calories);
        Assert.Equal(11000, top3[1].Calories);
        Assert.Equal(10000, top3[2].Calories);
        
        Assert.Equal(45000, top3.Sum(_ => _.Calories));
    }
    
    [Fact]
    public void Test2()
    {
        var fileName = "Day01/answer.txt";
        
        var caloriesCounter = new CaloriesCounter();
        caloriesCounter.Calculate(fileName);
        var (index, calories) = caloriesCounter.GetResult();
        var result = caloriesCounter.GetTop3().Sum(_ => _.Calories);
    }
}