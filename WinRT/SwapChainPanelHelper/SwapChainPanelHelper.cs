using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Interfaces.D3D;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Graphics.DirectX.Direct3D11;
using WinRT;

namespace Hi3Helper.Win32.WinRT.SwapChainPanelHelper;

public class SwapChainContext : IDisposable
{
    public IDXGISwapChain SwapChain { get; init; }
    public IDirect3DSurface[] SwapChainSurfaces { get; init; } = [];
    public IDXGISurface[] SwapChainDxgiSurfaces { get; init; } = [];
    public ID3D11Texture2D[] SwapChainBackBuffers { get; init; } = [];

    public readonly nint D3D11DeviceImmediateContextPointer;
    public readonly nint D3D11DevicePointer;

    internal SwapChainContext(IDXGISwapChain swapChain,
                              IDirect3DSurface[] swapChainSurfaces,
                              IDXGISurface[] swapChainDxgiSurfaces,
                              ID3D11Texture2D[] swapChainBackBuffers,
                              nint d3D11DeviceImmediateContextPointer,
                              nint d3D11DevicePointer)
    {
        SwapChain = swapChain;
        SwapChainSurfaces = swapChainSurfaces;
        SwapChainDxgiSurfaces = swapChainDxgiSurfaces;
        SwapChainBackBuffers = swapChainBackBuffers;
        D3D11DeviceImmediateContextPointer = d3D11DeviceImmediateContextPointer;
        D3D11DevicePointer = d3D11DevicePointer;
    }

    public void Dispose()
    {
        // Release the surfaces and buffers in order
        foreach (IDirect3DSurface surface in SwapChainBackBuffers)
        {
            ComMarshal<IDirect3DSurface>.TryReleaseComObject(surface, out _);
        }

        foreach (IDXGISurface dxgiSurface in SwapChainDxgiSurfaces)
        {
            ComMarshal<IDXGISurface>.TryReleaseComObject(dxgiSurface, out _);
        }

        foreach (ID3D11Texture2D texture in SwapChainSurfaces)
        {
            ComMarshal<ID3D11Texture2D>.TryReleaseComObject(texture, out _);
        }

        ComMarshal<IDXGISwapChain>.TryReleaseComObject(SwapChain, out _);

        if (D3D11DeviceImmediateContextPointer != nint.Zero)
        {
            Marshal.Release(D3D11DeviceImmediateContextPointer);
        }

        if (D3D11DevicePointer != nint.Zero)
        {
            Marshal.Release(D3D11DevicePointer);
        }

        GC.SuppressFinalize(this);
    }
}

public static class SwapChainPanelHelper
{
    public const int D3D11_SDK_VERSION = 7;

    public static unsafe void InitializeD3D11Device(
        IWinRTObject swapChainPanel,
        ref DXGI_SWAP_CHAIN_DESC description,
        out SwapChainContext? swapChainContext)
    {
        Unsafe.SkipInit(out swapChainContext);

        D3D_FEATURE_LEVEL[] featureLevels = [
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_1,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_3,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_2,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_1
        ];

        PInvoke.D3D11CreateDeviceAndSwapChain(
            nint.Zero,
            D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE,
            HMODULE.Null,
            D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT,
            featureLevels,
            featureLevels.Length,
            D3D11_SDK_VERSION,
            in description,
            out nint ppSwapChainP,
            out nint ppD3D11device,
            0u,
            out nint ppD3D11DeviceImmediateContext).ThrowOnFailure();

        if (!ComMarshal<IWinRTObject>.TryCastComObjectAs(swapChainPanel,
                                              out ISwapChainPanelNative? swapChainPanelNative,
                                              out Exception? ex))
        {
            throw ex;
        }

        swapChainPanelNative.SetSwapChain(ppSwapChainP);
        if (!ComMarshal<IDXGISwapChain>.TryCreateComObjectFromReference(ppSwapChainP,
                                                out IDXGISwapChain? swapChain,
                                                out ex))
        {
            throw ex;
        }

        Guid texture2dGuid = typeof(ID3D11Texture2D).GUID;

        ID3D11Texture2D[] swapChainBackBuffers = new ID3D11Texture2D[description.BufferCount];
        IDXGISurface[] swapChainDxgiSurfaces = new IDXGISurface[description.BufferCount];
        IDirect3DSurface[] swapChainSurfaces = new IDirect3DSurface[description.BufferCount];

        for (uint i = 0; i < swapChainBackBuffers.Length; i++)
        {
            // Get back-buffer
            swapChain.GetBuffer(i, in texture2dGuid, out nint ppSurface);

            // Create ID3D11Texture2D
            if (!ComMarshal<ID3D11Texture2D>.TryCreateComObjectFromReference(ppSurface,
                                                    out ID3D11Texture2D? currentTexture,
                                                    out ex))
            {
                throw ex;
            }

            // Create IDXGISurface
            if (!ComMarshal<IDXGISurface>.TryCreateComObjectFromReference(ppSurface,
                                                    out IDXGISurface? currentDxgiSurface,
                                                    out ex))
            {
                throw ex;
            }

            // Create IDirect3DSurface (this one uses WinRT's IInspectable. Troubling on getting this right for 2 hours bruh....)
            // No need to define the riid as it will be handled by WinRT itself.
            PInvoke.CreateDirect3D11SurfaceFromDXGISurface(ppSurface, out nint ppDirect3DSurface).ThrowOnFailure();
            IDirect3DSurface currentSurface = MarshalInspectable<IDirect3DSurface>.FromAbi(ppDirect3DSurface);

            swapChainBackBuffers[i] = currentTexture;
            swapChainDxgiSurfaces[i] = currentDxgiSurface;
            swapChainSurfaces[i] = currentSurface;
        }

        swapChainContext = new SwapChainContext(swapChain,
                                                swapChainSurfaces,
                                                swapChainDxgiSurfaces,
                                                swapChainBackBuffers,
                                                ppD3D11DeviceImmediateContext,
                                                ppD3D11device);

        ComMarshal<ISwapChainPanelNative>.TryReleaseComObject(swapChainPanelNative, out _);
    }
}
