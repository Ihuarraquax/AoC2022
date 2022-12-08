namespace AoC2022.CargoCrane;

public class CargoCrane
{
    private readonly Hold hold;
    private readonly bool isMultipleMove;
    
    public CargoCrane(Hold hold, bool isMultipleMove = false)
    {
        this.hold = hold;
        this.isMultipleMove = isMultipleMove;
    }

    public void ExecuteCommand(string command)
    {
        var (count, from, to) = ParseCommand(command);
        Move(count,from,to);
    }

    private (int count, int from, int to) ParseCommand(string command)
    {
        var splitted = command.Split(' ');

        return (int.Parse(splitted[1]), int.Parse(splitted[3]), int.Parse(splitted[5]));
    }

    private void Move(int count, int from, int to)
    {
        if (isMultipleMove)
        {
            var handle = new Stack<string>();
            for (int i = 0; i < count; i++)
            {
                handle.Push(hold.At(from).Pop());
            }
            for (int i = 0; i < count; i++)
            {
                hold.At(to).Push(handle.Pop());
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                var crate = hold.At(from).Pop();
                hold.At(to).Push(crate);
            }
        }

    }
}