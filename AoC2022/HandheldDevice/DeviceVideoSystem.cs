using AoC2022.HandheldDevice.Cpu;

namespace AoC2022.HandheldDevice;

public class DeviceVideoSystem
{
    public DeviceVideoSystem(params CpuCommand[] commands)
    {
        Cycle = new CircleCycle();
        Cpu = new Cpu.Cpu(commands);
        ReadHistory = new ReadHistory();
        Sprite = new Sprite();
        Crt = new Crt();

        Cycle.OnTickStart += (_, _) => ReadHistory.SaveRead(Cpu.RegistryXValue);
        Cycle.OnTick += (_, _) =>
            Crt.Render(
                Sprite.IsIn(position: (Cycle.CurrentCycle - 1) % 40)
            );
        Cycle.OnTickEnd += (_, _) => Cpu.Process();
        Cycle.OnTickEnd += (_, _) => Sprite.Position = Cpu.RegistryXValue;
    }

    public Cpu.Cpu Cpu { get; }
    public CircleCycle Cycle { get; }
    public ReadHistory ReadHistory { get; }
    public Sprite Sprite { get; }
    public Crt Crt { get; }

    public int GetSignalStrengthDuring(int tickNumber)
    {
        return tickNumber * ReadHistory.At(tickNumber);
    }

    public int SumSignalStrengthAt(params int[] cycles)
    {
        return cycles.Sum(GetSignalStrengthDuring);
    }
}