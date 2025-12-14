using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94")]
public partial interface IWICBitmapSource
{
    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize
    void GetSize(out uint puiWidth, out uint puiHeight);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat
    void GetPixelFormat(out Guid pPixelFormat);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution
    void GetResolution(out double pDpiX, out double pDpiY);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette
    void CopyPalette([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICPalette>))] IWICPalette pIPalette);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels
    void CopyPixels(in WICRect prc, uint cbStride, uint cbBufferSize, nint /* byte array */ pbBuffer);
}
