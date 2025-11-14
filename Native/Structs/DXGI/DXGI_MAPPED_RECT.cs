// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>Describes a mapped rectangle that is used to access a surface.</summary>
/// <remarks>The <b>DXGI_MAPPED_RECT</b> structure is initialized by the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgisurface-map">IDXGISurface::Map</a> method.</remarks>
public struct DXGI_MAPPED_RECT
{
    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">INT</a></b> A value that describes the width, in bytes, of the surface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_mapped_rect#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public int Pitch;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">BYTE</a>*</b> A pointer to the image buffer of the surface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_mapped_rect#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public unsafe byte* pBits;
}
