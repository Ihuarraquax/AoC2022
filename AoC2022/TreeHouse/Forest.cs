namespace AoC2022.TreeHouse;

public class Forest
{
    private readonly List<Tree> trees;

    public Forest(List<Tree> trees)
    {
        this.trees = trees;
    }

    public bool IsVisible(int row, int col) =>
        IsVisible(TreeAt(row, col));


    public Tree? TreeAt(int row, int col) => trees.FirstOrDefault(_ => _.Col == col && _.Row == row);

    public bool IsVisible(Tree tree)
    {
        return IsVisibleFromLeft() || IsVisibleFromRight() || IsVisibleFromTop() || IsVisibleFromBottom();

        bool IsVisibleFromLeft() => trees.Where(t => t.Col < tree.Col && t.Row == tree.Row)
            .All(_ => _.Height < tree.Height);

        bool IsVisibleFromRight() => trees.Where(t => t.Col > tree.Col && t.Row == tree.Row)
            .All(_ => _.Height < tree.Height);

        bool IsVisibleFromTop() => trees.Where(t => t.Col == tree.Col && t.Row < tree.Row)
            .All(_ => _.Height < tree.Height);

        bool IsVisibleFromBottom() =>
            trees.Where(t => t.Col == tree.Col && t.Row > tree.Row)
                .All(_ => _.Height < tree.Height);
    }

    public IEnumerable<Tree> GetVisibleTrees() =>
        trees.Where(IsVisible);

    public int GetHighestScenicScore() =>
        GetVisibleTrees().Max(GetScenicScore);

    public int GetScenicScore(int row, int col)
        => GetScenicScore(TreeAt(row, col));

    public int GetScenicScore(Tree tree) =>
        ScenicScoreFromLeft(tree) * ScenicScoreFromRight(tree) * ScenicScoreFromTop(tree) * ScenicScoreFromBottom(tree);

    public int ScenicScoreFromLeft(Tree tree)
    {
        return ScenicScoreForDirection(tree, 0, -1);
    }

    public int ScenicScoreFromRight(Tree tree)
    {
        return ScenicScoreForDirection(tree, 0, 1);
    }

    public int ScenicScoreFromTop(Tree tree)
    {
        return ScenicScoreForDirection(tree, -1, 0);
    }

    public int ScenicScoreFromBottom(Tree tree)
    {
        return ScenicScoreForDirection(tree, 1, 0);
    }
    
    private int ScenicScoreForDirection(Tree tree, int rowModifier, int colModifier)
    {
        var col = tree.Col;
        var row = tree.Row;
        var score = 0;

        while (true)
        {
            if (TreeAt(row + rowModifier, col + colModifier) is not { } nextTree)
                return score;

            score++;
            if (nextTree.Height >= tree.Height)
                return score;

            col += colModifier;
            row += rowModifier;
        }
    }
}