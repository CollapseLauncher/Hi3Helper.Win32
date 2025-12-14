using Hi3Helper.Win32.Native.Enums.D3D;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_COUNTER_INFO
{
    public D3D11_COUNTER LastDeviceDependentCounter;
    public uint NumSimultaneousCounters;
    public byte NumDetectableParallelUnits;
}
