using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("a44472e1-8dfb-4e60-8492-6e2861c9ca8b")]
public partial interface ID2D1Device2 : ID2D1Device1
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1device2-createdevicecontext
    void CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS options, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1DeviceContext2>))] out ID2D1DeviceContext2 deviceContext2);

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1device2-flushdevicecontexts
    [PreserveSig]
    void FlushDeviceContexts([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Bitmap>))] ID2D1Bitmap bitmap);

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1device2-getdxgidevice
    void GetDxgiDevice([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIDevice>))] out IDXGIDevice dxgiDevice);
}