namespace AoC2022;

public class HandheldDevice
{
    public bool FirstMarkerAppears => FirstMarkerAppearsAt != 0;

    public int FirstMarkerAppearsAt { get; private set; }
    
    private readonly int distinctCharacterCount;

    private readonly List<char> log = new();

    public HandheldDevice(MarkerType markerType)
    {
        distinctCharacterCount = markerType switch
        {
            MarkerType.StartOfMessage => 14,
            MarkerType.StartOfPacket => 4,
            _ => throw new ArgumentOutOfRangeException(nameof(markerType), markerType, null)
        };
    }

    public void ReceiveSignal(char signal)
    {
        log.Add(signal);

        if (log.TakeLast(distinctCharacterCount).Distinct().Count() != distinctCharacterCount) return;
        if (FirstMarkerAppearsAt == 0) FirstMarkerAppearsAt = log.Count;
    }
    
    public enum MarkerType
    {
        StartOfPacket,
        StartOfMessage
    }
}