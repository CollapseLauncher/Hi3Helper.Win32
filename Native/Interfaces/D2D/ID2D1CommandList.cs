using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("b4f34a19-2383-4d76-94f6-ec343657c3dc")]
public partial interface ID2D1CommandList : ID2D1Image
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandlist-stream
    void Stream([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1CommandSink>))] ID2D1CommandSink sink);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandlist-close
    void Close();
}