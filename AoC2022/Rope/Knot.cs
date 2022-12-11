namespace AoC2022.Rope;

public class Knot
{
    public event EventHandler Moved;

    public string Name { get; }
    public int X { get; set; }
    public int Y { get; set; }
    private Knot? Following { get; }

    public readonly ISet<Position> PositionsVisited = new HashSet<Position>();

    public Knot(string name, Knot? following = default)
    {
        Name = name;
        Following = following;

        if (Following is not null)
        {
            Following.Moved += (_, _) => Adjust();
        }

        PositionsVisited.Add(new Position(X, Y));
    }

    public void Move(int x, int y, int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            Move(x, y);
        }
    }

    public void Move(int x, int y)
    {
        X += x;
        Y += y;

        PositionsVisited.Add(new Position(X, Y));

        Moved?.Invoke(this, null!);
    }

    private void Adjust()
    {
        if (IsTouchingHead() is false)
            return;

        MoveToRemainClose();
    }

    private void MoveToRemainClose()
    {
        var xDiff = Following.X - X;
        var yDiff = Following.Y - Y;

        var moveX = 0;
        var moveY = 0;
        switch (xDiff)
        {
            case > 0:
                moveX = 1;
                break;
            case < 0:
                moveX = -1;
                break;
        }

        switch (yDiff)
        {
            case > 0:
                moveY = 1;
                break;
            case < 0:
                moveY = -1;
                break;
        }

        if (moveX != 0 || moveY != 0)
        {
            Move(moveX, moveY);
        }
    }

    private bool IsTouchingHead() => Math.Abs(Following.X - X) > 1 || Math.Abs(Following.Y - Y) > 1;
}