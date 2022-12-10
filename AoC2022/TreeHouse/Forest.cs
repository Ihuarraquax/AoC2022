using System.Drawing;

namespace AoC2022.TreeHouse;

public class Forest
{
    private List<Tree> Trees = new();
    private int colDimensionCount;
    private int rowDimensionCount;

    public Forest(int[,] treesGrid)
    {
        for (var col = 0; col < treesGrid.GetLength(0); col++)
        {
            for (var row = 0; row < treesGrid.GetLength(1); row++)
            {
                Trees.Add(new Tree(row, col, treesGrid[row, col]));
            }
        }

        CalculateDimensions();
    }

    public Forest(List<string> lines)
    {
        for (var col = 0; col < lines.Count(); col++)
        {
            for (int row = 0; row < lines[col].Length; row++)
            {
                Trees.Add(new Tree(row, col, int.Parse(lines[row][col].ToString())));
            }
        }

        CalculateDimensions();
    }

    private void CalculateDimensions()
    {
        colDimensionCount = Trees.Count(_ => _.Row == 0);
        rowDimensionCount = Trees.Count(_ => _.Col == 0);
    }

    public bool IsVisible(int row, int col) =>
        IsVisible(Trees.First(_ => _.Col == col && _.Row == row));

    public bool IsVisible(Tree tree)
    {
        return IsVisibleFromLeft() || IsVisibleFromRight() || IsVisibleFromTop() || IsVisibleFromBottom();

        bool IsVisibleFromLeft() => Trees.Where(t => t.Col < tree.Col && t.Row == tree.Row)
            .All(_ => _.Height < tree.Height);

        bool IsVisibleFromRight() => Trees.Where(t => t.Col > tree.Col && t.Row == tree.Row)
            .All(_ => _.Height < tree.Height);

        bool IsVisibleFromTop() => Trees.Where(t => t.Col == tree.Col && t.Row < tree.Row)
            .All(_ => _.Height < tree.Height);

        bool IsVisibleFromBottom() =>
            Trees.Where(t => t.Col == tree.Col && t.Row > tree.Row)
                .All(_ => _.Height < tree.Height);
    }

    public IEnumerable<Tree> GetVisibleTrees()
    {
        return Trees.Where(IsVisible);
    }

    public int GetHighestScenicScore()
    {
        return GetVisibleTrees().Max(GetScenicScore);
    }

    public int GetScenicScore(int x, int y)
        => GetScenicScore(Trees.First(_ => _.Col == x && _.Row == y));

    public int GetScenicScore(Tree tree)
    {
        return ScoreFromLeft(tree) * ScoreFromRight(tree) * ScoreFromTop(tree) * ScoreFromBottom(tree);
    }

    public int ScoreFromLeft(Tree tree)
    {
        var canSeeTrees = 0;
        var col = tree.Col--;

        while (col >= 0 && Trees.First(_ => _.Col == col && _.Row == tree.Row).Height <
               tree.Height)
        {
            canSeeTrees++;
            col--;
        }

        return canSeeTrees;
    }

    public int ScoreFromRight(Tree tree)
    {
        var canSeeTrees = 0;
        var col = tree.Col++;

        while (col < colDimensionCount &&
               Trees.First(_ => _.Col == col && _.Row == tree.Row).Height < tree.Height)
        {
            canSeeTrees++;
            col++;
        }

        return canSeeTrees;
    }

    public int ScoreFromTop(Tree tree)
    {
        var canSeeTrees = 0;
        var row = tree.Row--;

        while (row >= 0 && Trees.First(_ => _.Row == row && _.Col == tree.Col).Height <
               tree.Height)
        {
            canSeeTrees++;
            row--;
        }

        return canSeeTrees;
    }

    public int ScoreFromBottom(Tree tree)
    {
        var canSeeTrees = 0;
        var row = tree.Row++;

        while (row < rowDimensionCount &&
               Trees.First(_ => _.Row == row && _.Col == tree.Col).Height < tree.Height)
        {
            canSeeTrees++;
            row++;
        }

        return canSeeTrees;
    }

    public Tree TreeAt(int col, int row) => Trees.First(_ => _.Col == col && _.Row == row);
}