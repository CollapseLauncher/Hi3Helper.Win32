using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid("77db970f-6276-48ba-ba28-070143b4392c")]
public partial interface IDXGIDevice1 : IDXGIDevice
{
    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgidevice1-setmaximumframelatency
    void SetMaximumFrameLatency(uint MaxLatency);

    // https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgidevice1-getmaximumframelatency
    void GetMaximumFrameLatency(out uint pMaxLatency);
}
