namespace AoC2022.MonkeyInTheMiddle;

public class MonkeyOperation
{
    private readonly string left;
    private readonly string mathOperator;
    private readonly string right;
    public MonkeyOperation(string expression)
    {
        var tokens = expression.Split(' ');
        
        left = tokens[0];
        mathOperator = tokens[1];
        right = tokens[2];
    }

    public ulong CalculateNew(ulong old)
    {
        checked
        {
            var leftValue = left == "old" ? old : ulong.Parse(left);
            var rightValue = right == "old" ? old : ulong.Parse(right);

            return mathOperator switch
            {
                "*" => leftValue * rightValue,
                "+" => leftValue + rightValue,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}