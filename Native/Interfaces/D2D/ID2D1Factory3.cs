using Hi3Helper.Win32.Native.Interfaces.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0869759f-4f00-413f-b03e-2bda45404d0f")]
public partial interface ID2D1Factory3 : ID2D1Factory2
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice
    void CreateDevice([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIDevice>))] IDXGIDevice dxgiDevice, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Device2>))] out ID2D1Device2 d2dDevice2);
}
