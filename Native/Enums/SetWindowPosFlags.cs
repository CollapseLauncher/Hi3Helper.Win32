using System;

namespace Hi3Helper.Win32.Native.Enums
{
    // Reference:
    // https://pinvoke.net/default.aspx/Enums/SetWindowPosFlags.html
    [Flags]
    public enum SetWindowPosFlags : uint
    {
        SWP_NOSIZE = 1,
        SWP_NOMOVE = 2,
        SWP_NOZORDER = 4,
        SWP_FRAMECHANGED = 0x20,
        SWP_SHOWWINDOW = 0x40,
    }
}
