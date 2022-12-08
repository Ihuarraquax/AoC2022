namespace AoC2022.CargoCrane;

public class Stack
{
    readonly Stack<string> stack;

    public Stack(params string[] crates)
    {
        stack = new Stack<string>(crates);
    }

    public int Count => stack.Count;
    public string Top => stack.Peek();

    public string At(int position) => stack.ToList()[Count - position];

    public string Pop() => stack.Pop();
    public void Push(string crate) => stack.Push(crate);
}