namespace AoC2022.HandheldDevice.Cpu;

public class AddXCommand : CpuCommand
{
    private readonly int value;

    public AddXCommand(int value)
    {
        this.value = value;
    }

    public override int CyclesToComplete => 2;
    public override void OnComplete(Cpu cpu)
    {
        cpu.RegistryXValue += value;
    }
}