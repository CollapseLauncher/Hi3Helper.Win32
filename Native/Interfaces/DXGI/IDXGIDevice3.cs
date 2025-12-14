using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid("6007896c-3244-4afd-bf18-a6d3beda5023")]
public partial interface IDXGIDevice3 : IDXGIDevice2
{
    [PreserveSig]
    void Trim();
}
