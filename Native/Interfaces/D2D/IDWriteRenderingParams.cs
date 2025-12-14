using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("2f0da53a-2add-47cd-82ee-d9ec34688e75")]
public partial interface IDWriteRenderingParams
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getgamma
    [PreserveSig]
    float GetGamma();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getenhancedcontrast
    [PreserveSig]
    float GetEnhancedContrast();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getcleartypelevel
    [PreserveSig]
    float GetClearTypeLevel();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getpixelgeometry
    [PreserveSig]
    DWRITE_PIXEL_GEOMETRY GetPixelGeometry();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getrenderingmode
    [PreserveSig]
    DWRITE_RENDERING_MODE GetRenderingMode();
}
