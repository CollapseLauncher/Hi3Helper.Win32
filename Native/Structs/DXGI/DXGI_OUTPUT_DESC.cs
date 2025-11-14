using Hi3Helper.Win32.Native.Enums.DXGI;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

public unsafe struct DXGI_OUTPUT_DESC
{
    public const int MaxDeviceNameLength = 32;

    /// <summary>
    /// <para>Type: <b>WCHAR[32]</b> A string that contains the name of the output device.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public fixed char DeviceName[MaxDeviceNameLength];

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/windef/ns-windef-rect">RECT</a></b> A <a href="https://docs.microsoft.com/windows/desktop/api/windef/ns-windef-rect">RECT</a> structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch (DPI) of the desktop. For info about writing DPI-aware Win32 apps, see <a href="https://docs.microsoft.com/windows/desktop/hidpi/high-dpi-desktop-application-development-on-windows">High DPI</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public Rect DesktopCoordinates;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">BOOL</a></b> True if the output is attached to the desktop; otherwise, false.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public int AttachedToDesktop;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173065(v=vs.85)">DXGI_MODE_ROTATION</a></b> A member of the <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173065(v=vs.85)">DXGI_MODE_ROTATION</a> enumerated type describing on how an image is rotated by the output.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_MODE_ROTATION Rotation;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HMONITOR</a></b> An <a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">HMONITOR</a> handle that represents the display monitor. For more information, see <a href="https://docs.microsoft.com/windows/desktop/gdi/hmonitor-and-the-device-context">HMONITOR and the Device Context</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public nint Monitor;
}
