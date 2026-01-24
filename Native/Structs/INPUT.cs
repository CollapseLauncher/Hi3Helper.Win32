using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;


[StructLayout(LayoutKind.Sequential)]
public struct INPUT
{
    public uint       type;
    public KEYBDINPUT ki;
}

[StructLayout(LayoutKind.Sequential)]
public struct KEYBDINPUT
{
    public ushort wVk;
    public ushort wScan;
    public uint   dwFlags;
    public uint   time;
    public nint   dwExtraInfo;
}