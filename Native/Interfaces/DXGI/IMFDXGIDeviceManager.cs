using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid("eb533d5d-2db6-40f8-97a9-494692014f07")]
// https://github.com/smourier/DirectNAot/blob/0f81689b5f52ae792ee8cc236570d3058b0a2bf0/DirectN/Generated/DirectN/IMFDXGIDeviceManager.cs#L7
public partial interface IMFDXGIDeviceManager
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CloseDevicenint(nint hDevice);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetVideoService(nint hDevice, in Guid riid, out nint ppService);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult LockDevice(nint hDevice, in Guid riid, out nint ppUnkDevice, BOOL fBlock);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult OpenDevicenint(out nint phDevice);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ResetDevice(nint pUnkDevice, uint resetToken);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult TestDevice(nint hDevice);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult UnlockDevice(nint hDevice, BOOL fSaveState);
}
