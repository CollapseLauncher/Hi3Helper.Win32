using Hi3Helper.Win32.Native.Enums.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface, Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
public unsafe partial interface IDXGIResource : IDXGIDeviceSubObject
{
    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getsharedhandle
    void GetSharedHandle(out nint pSharedHandle);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getusage
    void GetUsage(out DXGI_USAGE pUsage);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiresource-setevictionpriority
    void SetEvictionPriority(DXGI_RESOURCE_PRIORITY EvictionPriority);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getevictionpriority
    void GetEvictionPriority(out DXGI_RESOURCE_PRIORITY pEvictionPriority);
}