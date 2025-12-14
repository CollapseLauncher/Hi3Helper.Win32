using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("00000123-a8f2-4877-ba0a-fd2b6645fb94")]
public partial interface IWICBitmapLock
{
    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getsize
    void GetSize(out uint puiWidth, out uint puiHeight);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getstride
    void GetStride(out uint pcbStride);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getdatapointer
    void GetDataPointer(out uint pcbBufferSize, out nint /* byte array */ ppbData);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getpixelformat
    void GetPixelFormat(out Guid pPixelFormat);
}