namespace AoC2022.HandheldDevice.Cpu;

public class Cpu
{
    readonly Queue<CpuCommand> commandQueue;

    CpuCommand? currentCommand;
    private int currentCycleInCommand;

    public Cpu(params CpuCommand[] commands)
    {
        commandQueue = new Queue<CpuCommand>(commands);
        
        LoadNextCommand();
    }

    public int RegistryXValue { get; set; } = 1;

    public void Process()
    {
        if (currentCommand is null)
        {
            return;
        }
        
        currentCycleInCommand++;
        if (currentCycleInCommand < currentCommand.CyclesToComplete)
        {
            return;
        }

        currentCommand.OnComplete(this);

        LoadNextCommand();
    }

    private void LoadNextCommand()
    {
        currentCycleInCommand = 0;
        currentCommand = commandQueue.TryDequeue(out var command) ? command : null;
    }
}