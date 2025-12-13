using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid("63AAD0B8-7C24-40FF-85A8-640D944CC325")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface ISwapChainPanelNative
{
    void SetSwapChain(nint swapChain);
}