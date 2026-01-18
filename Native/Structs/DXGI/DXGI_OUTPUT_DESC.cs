using Hi3Helper.Win32.Native.Enums.DXGI;
using System.Runtime.InteropServices;
using System.Threading;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct DXGI_OUTPUT_DESC
{
    public fixed char DeviceName[32];
    public Rect DesktopCoordinates;
    public BOOL AttachedToDesktop;
    public DXGI_MODE_ROTATION Rotation;
    public nint Monitor;
}
