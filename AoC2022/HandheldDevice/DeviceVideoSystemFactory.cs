using AoC2022.HandheldDevice.Cpu;

namespace AoC2022.HandheldDevice;

public static class DeviceVideoSystemFactory
{
    public static DeviceVideoSystem From(params string[] commands)
    {
        return new DeviceVideoSystem(commands.Select(ParseCommandFromText).ToArray());
    }

    private static CpuCommand ParseCommandFromText(string textCommand)
    {
        var tokens = textCommand.Split(' ');

        return tokens[0] switch
        {
            "noop" =>
                new NoopCommand(),
            "addx" =>
                new AddXCommand(int.Parse(tokens[1])),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}