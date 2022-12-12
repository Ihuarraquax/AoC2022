namespace AoC2022.HandheldDevice.Cpu;

public abstract class CpuCommand
{
    public abstract int CyclesToComplete { get; }

    public abstract void OnComplete(Cpu cpu);
}