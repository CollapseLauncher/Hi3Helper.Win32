using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("1c4820bb-5771-4518-a581-2fe4dd0ec657")]
public partial interface ID2D1ColorContext : ID2D1Resource
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1colorcontext-getcolorspace
    [PreserveSig]
    D2D1_COLOR_SPACE GetColorSpace();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1colorcontext-getprofilesize
    [PreserveSig]
    uint GetProfileSize();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1colorcontext-getprofile
    void GetProfile(nint /* byte array */ profile, uint profileSize);
}