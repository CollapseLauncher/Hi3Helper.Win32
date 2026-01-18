using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable InvalidXmlDocComment

// The code was source generated from CsWin32, then adjusted to work with GeneratedComInterface
namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIObject)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIObject
{
    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedata
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetPrivateData(in Guid Name, uint DataSize, nint pData);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedatainterface
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetPrivateDataInterface(in Guid Name, nint pUnknown);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getprivatedata
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetPrivateData(in Guid Name, ref uint pDataSize, nint pData);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetParent(in Guid riid, out nint /* void */ ppParent);
}
