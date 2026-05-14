using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("00000121-a8f2-4877-ba0a-fd2b6645fb94")]
public partial interface IWICBitmap : IWICBitmapSource
{
    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmap-lock
    void Lock(in WICRect prcLock, uint flags, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapLock>))] out IWICBitmapLock ppILock);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmap-setpalette
    void SetPalette([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICPalette>))] IWICPalette pIPalette);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicbitmap-setresolution
    void SetResolution(double dpiX, double dpiY);
}