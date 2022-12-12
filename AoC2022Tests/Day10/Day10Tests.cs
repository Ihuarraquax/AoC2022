using AoC2022.HandheldDevice;
using AoC2022.HandheldDevice.Cpu;

namespace AoC2022Tests.Day10;

public class Day10Tests
{
    [Fact]
    public void Test1()
    {
        var cycle = new CircleCycle();
        var cpu = new Cpu(new NoopCommand(), new AddXCommand(3), new AddXCommand(-5));
        var cycleHistory = new ReadHistory();

        cycle.OnTickStart += (_, _) => cycleHistory.SaveRead(cpu.RegistryXValue);
        cycle.OnTickEnd += (_, _) => cpu.Process();
        cpu.RegistryXValue.Should().Be(1);

        cycle.Tick(6);

        cycleHistory.At(1).Should().Be(1);
        cycleHistory.At(2).Should().Be(1);
        cycleHistory.At(3).Should().Be(1);
        cycleHistory.At(4).Should().Be(4);
        cycleHistory.At(5).Should().Be(4);
        cycleHistory.At(6).Should().Be(-1);
    }

    [Fact]
    public void Test2()
    {
        var deviceVideoSystem = new DeviceVideoSystem(new NoopCommand(), new AddXCommand(3), new AddXCommand(-5));

        deviceVideoSystem.Cpu.RegistryXValue.Should().Be(1);

        deviceVideoSystem.Cycle.Tick(6);

        deviceVideoSystem.ReadHistory.At(1).Should().Be(1);
        deviceVideoSystem.ReadHistory.At(2).Should().Be(1);
        deviceVideoSystem.ReadHistory.At(3).Should().Be(1);
        deviceVideoSystem.ReadHistory.At(4).Should().Be(4);
        deviceVideoSystem.ReadHistory.At(5).Should().Be(4);
        deviceVideoSystem.ReadHistory.At(6).Should().Be(-1);
    }

    [Fact]
    public void Test3()
    {
        var deviceVideoSystem = DeviceVideoSystemFactory.From(File.ReadAllLines("Day10/test.txt"));

        deviceVideoSystem.Cycle.Tick(220);

        deviceVideoSystem.GetSignalStrengthDuring(20).Should().Be(420);
        deviceVideoSystem.GetSignalStrengthDuring(60).Should().Be(1140);
        deviceVideoSystem.GetSignalStrengthDuring(100).Should().Be(1800);
        deviceVideoSystem.GetSignalStrengthDuring(140).Should().Be(2940);
        deviceVideoSystem.GetSignalStrengthDuring(180).Should().Be(2880);
        deviceVideoSystem.GetSignalStrengthDuring(220).Should().Be(3960);

        deviceVideoSystem.SumSignalStrengthAt(20, 60, 100, 140, 180, 220).Should().Be(13140);
    }

    [Fact]
    public void Test4()
    {
        var deviceVideoSystem = DeviceVideoSystemFactory.From(File.ReadAllLines("Day10/answer.txt"));

        deviceVideoSystem.Cycle.Tick(240);

        deviceVideoSystem.SumSignalStrengthAt(20, 60, 100, 140, 180, 220).Should().Be(15360);
    }

    [Fact]
    public void Test5()
    {
        var deviceVideoSystem = DeviceVideoSystemFactory.From(File.ReadAllLines("Day10/test.txt"));
        var cycle = deviceVideoSystem.Cycle;
        var sprite = deviceVideoSystem.Sprite;
        var crt = deviceVideoSystem.Crt;
        // #1
        // Before
        sprite.Position.Should().Be(1);
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("#");
        // After

        // #2
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##");
        // After
        sprite.Position.Should().Be(16);

        // #3
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##.");
        // After
        sprite.Position.Should().Be(16);

        // #4
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..");
        // After
        sprite.Position.Should().Be(5);

        // #5
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..#");
        // After
        sprite.Position.Should().Be(5);

        // #6
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##");
        // After
        sprite.Position.Should().Be(11);

        // #7
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##.");
        // After
        sprite.Position.Should().Be(11);

        // #8
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##..");
        // After
        sprite.Position.Should().Be(8);


        // #9
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##..#");
        // After
        sprite.Position.Should().Be(8);

        // #10
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##..##");
        // After
        sprite.Position.Should().Be(13);

        // #11
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##..##.");
        // After
        sprite.Position.Should().Be(13);

        // #12
        cycle.Tick();
        // During
        crt.CurrentRowDisplay().Should().Be("##..##..##..");
        // After
        sprite.Position.Should().Be(12);


        cycle.Tick(240 - 12);

        crt.DisplayInLine().Should().BeEquivalentTo(
            "##..##..##..##..##..##..##..##..##..##..###...###...###...###...###...###...###.####....####....####....####....####....#####.....#####.....#####.....#####.....######......######......######......###########.......#######.......#######.....");
    }
    
    [Fact]
    public void Test8()
    {
        var deviceVideoSystem = DeviceVideoSystemFactory.From(File.ReadAllLines("Day10/answer.txt"));

        deviceVideoSystem.Cycle.Tick(240);

        deviceVideoSystem.Crt.Print();
    }
}