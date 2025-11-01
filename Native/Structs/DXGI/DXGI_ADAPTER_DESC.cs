// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnassignedField.Global
#pragma warning disable IDE0051

namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>Describes an adapter (or video card) using DXGI 1.0.</summary>
/// <remarks>The <b>DXGI_ADAPTER_DESC1</b> structure provides a DXGI 1.0 description of an adapter.  This structure is initialized by using the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1">IDXGIAdapter1::GetDesc1</a> method.</remarks>
public unsafe struct DXGI_ADAPTER_DESC
{
    public const int MaxDescriptionLength = 128;

    /// <summary>
    /// <para>Type: <b>WCHAR[128]</b> A string that contains the adapter description. On <a href="https://docs.microsoft.com/windows/desktop/direct3d11/overviews-direct3d-11-devices-downlevel-intro">feature level</a> 9 graphics hardware, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1">GetDesc1</a> returns “Software Adapter” for the description string.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public fixed char Description[MaxDescriptionLength];

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The PCI ID of the hardware vendor. On <a href="https://docs.microsoft.com/windows/desktop/direct3d11/overviews-direct3d-11-devices-downlevel-intro">feature level</a> 9 graphics hardware, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1">GetDesc1</a> returns zeros for the PCI ID of the hardware vendor.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint VendorId;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The PCI ID of the hardware device. On <a href="https://docs.microsoft.com/windows/desktop/direct3d11/overviews-direct3d-11-devices-downlevel-intro">feature level</a> 9 graphics hardware, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1">GetDesc1</a> returns zeros for the PCI ID of the hardware device.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint DeviceId;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The PCI ID of the sub system. On <a href="https://docs.microsoft.com/windows/desktop/direct3d11/overviews-direct3d-11-devices-downlevel-intro">feature level</a> 9 graphics hardware, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1">GetDesc1</a> returns zeros for the PCI ID of the sub system.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint SubSysId;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The PCI ID of the revision number of the adapter. On <a href="https://docs.microsoft.com/windows/desktop/direct3d11/overviews-direct3d-11-devices-downlevel-intro">feature level</a> 9 graphics hardware, <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1">GetDesc1</a> returns zeros for the PCI ID of the revision number of the adapter.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Revision;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">SIZE_T</a></b> The number of bytes of dedicated video memory that are not shared with the CPU.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public nuint DedicatedVideoMemory;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">SIZE_T</a></b> The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system memory at boot time.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public nuint DedicatedSystemMemory;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">SIZE_T</a></b> The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public nuint SharedSystemMemory;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/hardware/drivers/ff549708(v=vs.85)">LUID</a></b> A unique value that identifies the adapter. See <a href="https://docs.microsoft.com/previous-versions/windows/hardware/drivers/ff549708(v=vs.85)">LUID</a> for a definition of the structure. <b>LUID</b> is defined in dxgi.h.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public LUID AdapterLuid;
}