using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct XINPUT_STATE
{
    public uint           dwPacketNumber;
    public XINPUT_GAMEPAD Gamepad;
}

[StructLayout(LayoutKind.Sequential)]
public struct XINPUT_GAMEPAD
{
    public ushort wButtons;
    public byte   bLeftTrigger;
    public byte   bRightTrigger;
    public short  sThumbLX;
    public short  sThumbLY;
    public short  sThumbRX;
    public short  sThumbRY;
}
