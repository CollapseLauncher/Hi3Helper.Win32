// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming
#pragma warning disable IDE0051
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>Represents a rational number.</summary>
/// <remarks>
/// <para>This structure is a member of the <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb173064(v=vs.85)">DXGI_MODE_DESC</a> structure. The <b>DXGI_RATIONAL</b> structure operates under the following rules: </para>
/// <para>This doc was truncated.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
public struct DXGI_RATIONAL
{
    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> An unsigned integer value representing the top of the rational number.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Numerator;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> An unsigned integer value representing the bottom of the rational number.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Denominator;
}
