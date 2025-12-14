using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Interfaces.D2D;
using Hi3Helper.Win32.Native.Interfaces.D3D;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
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
        double xamlScaleFactor,
        ref DXGI_SWAP_CHAIN_DESC1 description,
        out SwapChainContext? swapChainContext)
    {
        Unsafe.SkipInit(out swapChainContext);
        Unsafe.SkipInit(out nint ppSwapChainP);

        D3D_FEATURE_LEVEL[] featureLevels = [
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_1,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_3,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_2,
            D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_1
        ];

        CreateD3D11Device(featureLevels,
            out nint ppd3d11Device,
            out var d3d11Device,
            out var d3d11DeviceContext,
            out var dxgiDevice,
            out var d2d1Device,
            out var d2d1DeviceContext);

        Guid dxgiFactoryGuid = typeof(IDXGIFactory4).GUID;

        dxgiDevice.GetAdapter(out IDXGIAdapter dxgiAdapter); // Device -> Adapter
        dxgiAdapter.GetParent(in dxgiFactoryGuid, out nint dxgiFactoryPpv); // Adapter -> Factory
        if (!ComMarshal<IDXGIFactory4>.TryCreateComObjectFromReference(dxgiFactoryPpv,
                                              out IDXGIFactory4? dxgiFactory,
                                              out Exception? ex))
        {
            throw ex;
        }

        // Create SwapChain and assign it to the SwapChainPanel
        dxgiFactory.CreateSwapChainForComposition(ppd3d11Device, in description, null, out IDXGISwapChain1? dxgiSwapChain);
        if (!ComMarshal<IWinRTObject>.TryCastComObjectAs(swapChainPanel,
                                              out ISwapChainPanelNative? swapChainPanelNative,
                                              out ex))
        {
            throw ex;
        }
        swapChainPanelNative.SetSwapChain(dxgiSwapChain);
        // From Microsoft Documentation at: https://github.com/microsoft/Xaml-Islands-Samples/blob/c0f357a2b16591001b7796d73f80651f2813cb1a/Standalone_Samples/WinForms_WPF_Core3/Native_SwapChainPanel_Comp/Direct2DPanel.cpp
        // Ensure that DXGI does not queue more than one frame at a time. This both reduces
        // latency and ensures that the application will only render after each VSync, minimizing
        // power consumption.
        dxgiDevice.SetMaximumFrameLatency(1);

        // From Microsoft Documentation at: https://github.com/microsoft/Xaml-Islands-Samples/blob/c0f357a2b16591001b7796d73f80651f2813cb1a/Standalone_Samples/WinForms_WPF_Core3/Native_SwapChainPanel_Comp/Direct2DPanel.cpp
        // Ensure the physical pixel size of the swap chain takes into account both the XAML SwapChainPanel's logical layout size and
        // any cumulative composition scale applied due to zooming, render transforms, or the system's current scaling plateau.
        // For example, if a 100x100 SwapChainPanel has a cumulative 2x scale transform applied, we instead create a 200x200 swap chain
        // to avoid artifacts from scaling it up by 2x, then apply an inverse 1/2x transform to the swap chain to cancel out the 2x transform.
        DXGI_MATRIX_3X2_F inverseScale = new DXGI_MATRIX_3X2_F
        {
            _11 = (float)(1.0 / xamlScaleFactor),
            _22 = (float)(1.0 / xamlScaleFactor),
            _12 = 0f,
            _21 = 0f,
            _31 = 0f,
            _32 = 0f
        };
        // Try query IDXGISwapChain2 to set the inverse scale
        if (ComMarshal<IDXGISwapChain1>.TryCastComObjectAs(dxgiSwapChain,
                                              out IDXGISwapChain2? dxgiSwapChain2,
                                              out _,
                                              true))
        {
            dxgiSwapChain2.SetMatrixTransform(in inverseScale);
        }
    }

    private static unsafe void CreateD3D11Device(
        D3D_FEATURE_LEVEL[] featureLevels,
        out nint ppD3D11device,
        out ID3D11Device3 d3d11Device,
        out ID3D11DeviceContext3 d3d11DeviceContext,
        out IDXGIDevice3 dxgiDevice,
        out ID2D1Device2 d2d1Device,
        out ID2D1DeviceContext2 d2d1DeviceContext)
    {
        Unsafe.SkipInit(out ppD3D11device);
        Unsafe.SkipInit(out d3d11Device);
        Unsafe.SkipInit(out d3d11DeviceContext);
        Unsafe.SkipInit(out dxgiDevice);
        Unsafe.SkipInit(out d2d1Device);
        Unsafe.SkipInit(out d2d1DeviceContext);

        D3D11_CREATE_DEVICE_FLAG flags = D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT;
#if DEBUG
        flags |= D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_DEBUG;
#endif

        PInvoke.D3D11CreateDevice(
            nint.Zero,
            D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE,
            HMODULE.Null,
            flags,
            featureLevels,
            featureLevels.Length,
            D3D11_SDK_VERSION,
            out ppD3D11device,
            0u,
            out nint ppD3D11DeviceImmediateContext).ThrowOnFailure();

        if (!ComMarshal<ID3D11Device3>.TryCreateComObjectFromReference(ppD3D11device,
                                              out d3d11Device,
                                              out Exception? ex))
        {
            throw ex;
        }

        if (!ComMarshal<IDXGIDevice3>.TryCreateComObjectFromReference(ppD3D11device,
                                              out dxgiDevice,
                                              out ex))
        {
            throw ex;
        }

        if (!ComMarshal<ID3D11DeviceContext3>.TryCreateComObjectFromReference(ppD3D11DeviceImmediateContext,
                                              out d3d11DeviceContext,
                                              out ex))
        {
            throw ex;
        }

        CreateD2DFactory(out ID2D1Factory3 d2d1Factory);
        d2d1Factory.CreateDevice(dxgiDevice, out d2d1Device);
        d2d1Device.CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS.D2D1_DEVICE_CONTEXT_OPTIONS_NONE, out d2d1DeviceContext);
        d2d1DeviceContext.SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE.D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE);
    }

    private static void CreateD2DFactory(out ID2D1Factory3 d2d1Factory)
    {
        D2D1_FACTORY_OPTIONS option = default;

#if DEBUG
        option.debugLevel = D2D1_DEBUG_LEVEL.D2D1_DEBUG_LEVEL_INFORMATION;
#else
        option.debugLevel = D2D1_DEBUG_LEVEL.D2D1_DEBUG_LEVEL_NONE;
#endif

        PInvoke.D2D1CreateFactory(
            D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_SINGLE_THREADED,
            typeof(ID2D1Factory3).GUID,
            in option,
            out nint ppD2D1Factory).ThrowOnFailure();

        if (!ComMarshal<ID2D1Factory3>.TryCreateComObjectFromReference(ppD2D1Factory,
                                              out d2d1Factory,
                                              out Exception? ex))
        {
            throw ex;
        }
    }
}
