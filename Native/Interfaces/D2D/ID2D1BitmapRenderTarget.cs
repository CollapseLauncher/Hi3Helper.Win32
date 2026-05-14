using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("2cd90695-12e2-11dc-9fed-001143a055f9")]
public partial interface ID2D1BitmapRenderTarget : ID2D1RenderTarget
{
    // https://learn.microsoft.com/windows/win32/api/d2d1/nf-d2d1-id2d1bitmaprendertarget-getbitmap
    void GetBitmap([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Bitmap>))] out ID2D1Bitmap bitmap);
}