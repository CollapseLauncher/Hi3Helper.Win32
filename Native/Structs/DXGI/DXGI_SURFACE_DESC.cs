using Hi3Helper.Win32.Native.Enums.DXGI;
// ReSharper disable InconsistentNaming
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>Describes a surface.</summary>
/// <remarks>This structure is used by the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgisurface-getdesc">GetDesc</a> and  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgidevice-createsurface">CreateSurface</a> methods.</remarks>
public struct DXGI_SURFACE_DESC
{
    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> A value describing the surface width.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Width;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> A value describing the surface height.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Height;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a></b> A member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgiformat/ne-dxgiformat-dxgi_format">DXGI_FORMAT</a> enumerated type that describes the surface format.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_FORMAT Format;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc">DXGI_SAMPLE_DESC</a></b> A member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc">DXGI_SAMPLE_DESC</a> structure that describes multi-sampling parameters for the surface.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public DXGI_SAMPLE_DESC SampleDesc;
}
