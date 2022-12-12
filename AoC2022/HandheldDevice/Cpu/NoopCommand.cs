namespace AoC2022.HandheldDevice.Cpu;

public class NoopCommand : CpuCommand
{
    public override int CyclesToComplete => 1;
    public override void OnComplete(Cpu cpu)
    {
        // do nothing
    }
}