namespace AoC2022.HandheldDevice;

public class CircleCycle
{
    public event EventHandler OnTickStart;
    public event EventHandler OnTick;
    public event EventHandler OnTickEnd;

    public int CurrentCycle { get; private set; }

    public void Tick(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Tick();
        }
    }

    public void Tick()
    {
        CurrentCycle++;
        
        OnTickStart?.Invoke(this, null);
        
        OnTick?.Invoke(this, null);

        OnTickEnd?.Invoke(this, null);
    }
}