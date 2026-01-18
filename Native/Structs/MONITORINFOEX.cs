using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MONITORINFOEXW
{
    public       int  cbSize;
    public       Rect rcMonitor;
    public       Rect rcWork;
    public       int  dwFlags;
    public fixed char szDevice[32];

    public MONITORINFOEXW()
    {
        cbSize = sizeof(MONITORINFOEXW);
    }

    public ReadOnlySpan<char> DeviceNameSpan
    {
        get
        {
            fixed (char* charPtr = &szDevice[0])
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(charPtr);
            }
        }
    }
}
