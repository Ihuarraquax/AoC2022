
namespace AoC2022.TreeHouse;

public class Tree
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Height { get; }
    
    public Tree(int row, int col, int height)
    {
        Row = row;
        Col = col;
        Height = height;
    }
}