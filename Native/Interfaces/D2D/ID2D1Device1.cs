using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("d21768e1-23a4-4823-a14b-7c3eba85d658")]
public partial interface ID2D1Device1 : ID2D1Device
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1device1-getrenderingpriority
    [PreserveSig]
    D2D1_RENDERING_PRIORITY GetRenderingPriority();

    // https://learn.microsoft.com/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1device1-setrenderingpriority
    [PreserveSig]
    void SetRenderingPriority(D2D1_RENDERING_PRIORITY renderingPriority);

    void CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS options, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1DeviceContext1>))] out ID2D1DeviceContext1 deviceContext1);
}