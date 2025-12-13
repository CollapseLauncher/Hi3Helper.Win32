using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid("54ec77fa-1377-44e6-8c32-88fd5f44c84c")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIDevice : IDXGIObject
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetAdapter([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIAdapter>))] out IDXGIAdapter pAdapter); [PreserveSig]

    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateSurface(in DXGI_SURFACE_DESC pDesc, uint NumSurfaces, DXGI_USAGE Usage, nint /* optional DXGI_SHARED_RESOURCE* */ pSharedResource, [In][Out][MarshalUsing(CountElementName = nameof(NumSurfaces))] nint[] ppSurface);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult QueryResourceResidency([In][Out][MarshalUsing(CountElementName = nameof(NumResources))] nint[] ppResources, [In][Out][MarshalUsing(CountElementName = nameof(NumResources))] DXGI_RESIDENCY[] pResidencyStatus, uint NumResources);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetGPUThreadPriority(int Priority);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetGPUThreadPriority(out int pPriority);
}
