namespace AoC2022.TreeHouse;

public static class ForestFactory
{
    public static Forest From(int[,] treesGrid)
    {
        var trees = new List<Tree>();
        for (var col = 0; col < treesGrid.GetLength(0); col++)
        {
            for (var row = 0; row < treesGrid.GetLength(1); row++)
            {
                trees.Add(new Tree(row, col, treesGrid[row, col]));
            }
        }

        return new Forest(trees);
    }

    public static Forest From(List<string> lines)
    {
        var trees = new List<Tree>();

        for (var col = 0; col < lines.Count(); col++)
        {
            for (int row = 0; row < lines[col].Length; row++)
            {
                trees.Add(new Tree(row, col, int.Parse(lines[row][col].ToString())));
            }
        }

        return new Forest(trees);
    }
}