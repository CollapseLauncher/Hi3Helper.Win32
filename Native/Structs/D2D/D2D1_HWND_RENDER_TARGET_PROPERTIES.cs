using Hi3Helper.Win32.Native.Enums.D2D;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct D2D1_HWND_RENDER_TARGET_PROPERTIES
{
    public nint hwnd;
    public D2D_SIZE_U pixelSize;
    public D2D1_PRESENT_OPTIONS presentOptions;
}
