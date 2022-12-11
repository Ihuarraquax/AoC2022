namespace AoC2022.Rope;

public class Rope
{
    public LinkedList<Knot> Knots = new();

    public readonly Knot Head;

    public Knot Tail => Knots.Last?.Value ?? Head;

    public Rope(params string[] followingKnots)
    {
        Head = new Knot("H");
        Knots.AddLast(Head);

        AddFollowingKnots(followingKnots);
    }

    private void AddFollowingKnots(string[] knotsNames)
    {
        foreach (var knotName in knotsNames) 
            Knots.AddLast(new Knot(knotName, Knots.Last.Value));
    }

    public void MoveRight(int steps)
    {
        Head.Move(1, 0, steps);
    }

    public void MoveLeft(int steps)
    {
        Head.Move(-1, 0, steps);
    }

    public void MoveDown(int steps)
    {
        Head.Move(0, -1, steps);
    }

    public void MoveUp(int steps)
    {
        Head.Move(0, 1, steps);
    }
}