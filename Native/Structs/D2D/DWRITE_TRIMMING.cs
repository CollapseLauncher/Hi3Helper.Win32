using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct DWRITE_TRIMMING
{
    public DWRITE_TRIMMING_GRANULARITY granularity;
    public uint delimiter;
    public uint delimiterCount;
}