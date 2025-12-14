using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("28acf509-7f5c-48f6-8611-f316010a6380")]
public partial interface ID3D11UnorderedAccessView : ID3D11View
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11unorderedaccessview-getdesc
    [PreserveSig]
    void GetDesc(out D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc);
}
