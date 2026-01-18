using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIOutput)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IDXGIOutput : IDXGIObject
{
    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdesc
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetDesc(out DXGI_OUTPUT_DESC pDesc);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetDisplayModeList(DXGI_FORMAT EnumFormat, DXGI_ENUM_MODES Flags, ref uint pNumModes, nint /* optional DXGI_MODE_DESC* */ pDesc);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult FindClosestMatchingMode(in DXGI_MODE_DESC pModeToMatch, out DXGI_MODE_DESC pClosestMatch, nint pConcernedDevice);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-waitforvblank
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult WaitForVBlank();

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-takeownership
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult TakeOwnership(nint pDevice, BOOL Exclusive);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-releaseownership
    [PreserveSig]
    void ReleaseOwnership();

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrolcapabilities
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetGammaControlCapabilities(out DXGI_GAMMA_CONTROL_CAPABILITIES pGammaCaps);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setgammacontrol
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetGammaControl(in DXGI_GAMMA_CONTROL pArray);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrol
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetGammaControl(out DXGI_GAMMA_CONTROL pArray);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setdisplaysurface
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetDisplaySurface([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGISurface>))] IDXGISurface pScanoutSurface);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaysurfacedata
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetDisplaySurfaceData([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGISurface>))] IDXGISurface pDestination);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getframestatistics
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetFrameStatistics(out DXGI_FRAME_STATISTICS pStats);
}