namespace AoC2022.Rope;

public static class RopeFactory
{
    public static Rope HeadTailRopeFrom(List<string> lines)
    {
        var rope = new Rope("9");
        foreach (var tokens in lines.Select(line => line.Split(' ')))
        {
            switch (tokens[0])
            {
                case "R":
                    rope.MoveRight(int.Parse(tokens[1]));
                    break;
                case "L":
                    rope.MoveLeft(int.Parse(tokens[1]));
                    break;
                case "U":
                    rope.MoveUp(int.Parse(tokens[1]));
                    break;
                case "D":
                    rope.MoveDown(int.Parse(tokens[1]));
                    break;
            }
        }

        return rope;
    }

    public static Rope TenKnotsRopeFrom(List<string> lines)
    {
        var rope = new Rope("1", "2", "3", "4", "5", "6", "7", "8", "9");
        foreach (var tokens in lines.Select(line => line.Split(' ')))
        {
            switch (tokens[0])
            {
                case "R":
                    rope.MoveRight(int.Parse(tokens[1]));
                    break;
                case "L":
                    rope.MoveLeft(int.Parse(tokens[1]));
                    break;
                case "U":
                    rope.MoveUp(int.Parse(tokens[1]));
                    break;
                case "D":
                    rope.MoveDown(int.Parse(tokens[1]));
                    break;
            }
        }

        return rope;
    }
}