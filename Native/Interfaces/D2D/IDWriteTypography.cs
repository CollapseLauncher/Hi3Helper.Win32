using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("55f1112b-1dc2-4b3c-9541-f46894ed85b6")]
public partial interface IDWriteTypography
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetypography-addfontfeature
    void AddFontFeature(DWRITE_FONT_FEATURE fontFeature);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetypography-getfontfeaturecount
    [PreserveSig]
    uint GetFontFeatureCount();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritetypography-getfontfeature
    void GetFontFeature(uint fontFeatureIndex, out DWRITE_FONT_FEATURE fontFeature);
}