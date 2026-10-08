using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid("a8be2ac4-199f-4946-b331-79599fb98de7")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public unsafe partial interface IDXGISwapChain2 : IDXGISwapChain1
{
    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-setsourcesize
    void SetSourceSize(uint Width, uint Height);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getsourcesize
    void GetSourceSize(out uint pWidth, out uint pHeight);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-setmaximumframelatency
    void SetMaximumFrameLatency(uint MaxLatency);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getmaximumframelatency
    void GetMaximumFrameLatency(out uint pMaxLatency);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getframelatencywaitableobject
    [PreserveSig]
    nint GetFrameLatencyWaitableObject();

    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-setmatrixtransform
    void SetMatrixTransform(in Matrix3x2 pMatrix);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getmatrixtransform
    void GetMatrixTransform(out Matrix3x2 pMatrix);
}
