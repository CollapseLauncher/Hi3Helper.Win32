using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("00000040-a8f2-4877-ba0a-fd2b6645fb94")]
public partial interface IWICPalette
{
    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializepredefined
    void InitializePredefined(WICBitmapPaletteType ePaletteType, BOOL fAddTransparentColor);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializecustom
    void InitializeCustom([In][MarshalUsing(CountElementName = nameof(cCount))] uint[] pColors, uint cCount);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializefrombitmap
    void InitializeFromBitmap([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapSource>))] IWICBitmapSource pISurface, uint cCount, BOOL fAddTransparentColor);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializefrompalette
    void InitializeFromPalette([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICPalette>))] IWICPalette pIPalette);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-gettype
    void GetType(out WICBitmapPaletteType pePaletteType);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-getcolorcount
    void GetColorCount(out uint pcCount);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-getcolors
    void GetColors(uint cCount, [In][Out][MarshalUsing(CountElementName = nameof(cCount))] uint[] pColors, out uint pcActualColors);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-isblackwhite
    void IsBlackWhite(out BOOL pfIsBlackWhite);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-isgrayscale
    void IsGrayscale(out BOOL pfIsGrayscale);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwicpalette-hasalpha
    void HasAlpha(out BOOL pfHasAlpha);
}