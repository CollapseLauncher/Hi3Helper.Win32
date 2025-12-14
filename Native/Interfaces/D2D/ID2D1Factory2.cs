using Hi3Helper.Win32.Native.Interfaces.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("94f81a73-9212-4376-9c58-b16a3a0d3992")]
public partial interface ID2D1Factory2 : ID2D1Factory1
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice
    void CreateDevice([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIDevice>))] IDXGIDevice dxgiDevice, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Device1>))] out ID2D1Device1 d2dDevice1);
}
