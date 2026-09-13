using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct LPSYSTEMTIME
{
    public ushort wYear;
    public ushort wMonth;
    public ushort wDayOfWeek;
    public ushort wDay;
    public ushort wHour;
    public ushort wMinute;
    public ushort wSecond;
    public ushort wMilliseconds;
}
