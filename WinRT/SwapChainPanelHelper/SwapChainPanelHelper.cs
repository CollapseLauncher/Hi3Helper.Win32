using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Enums.DXGI;
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

public static partial class SwapChainPanelHelper
{
    public const int D3D11_SDK_VERSION = 7;

    private static Guid IDXGISurface_IID = typeof(IDXGISurface).GUID;
    private static Guid IDXGIFactory_IID = typeof(IDXGIFactory4).GUID;
    private static Guid ID2D1Factory3_IID = typeof(ID2D1Factory3).GUID;

    public static ReadOnlySpan<D3D_FEATURE_LEVEL> FeatureLevels => [
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_1,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_3,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_2,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_1
    ];

    public static unsafe void GetNativeSurfaceImageSource(
        IWinRTObject surfaceImageSource,
        out ISurfaceImageSourceNativeWithD2D nativeObject)
    {
        const D3D_DRIVER_TYPE DriverType = D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE;

        D3D11_CREATE_DEVICE_FLAG flags = D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT;
        D3D_FEATURE_LEVEL supportedD3DFeature = default;

        PInvoke.D3D11CreateDevice(
            nint.Zero,
            DriverType,
            nint.Zero,
            flags,
            in MemoryMarshal.GetReference(FeatureLevels),
            FeatureLevels.Length,
            D3D11_SDK_VERSION,
            out nint ppD3D11device,
            ref supportedD3DFeature,
            out nint ppD3D11DeviceImmediateContext).ThrowOnFailure();

        D2D1_CREATION_PROPERTIES option = default;
        option.threadingMode = D2D1_THREADING_MODE.D2D1_THREADING_MODE_MULTI_THREADED;

        if (!ComMarshal<IDXGIDevice3>.TryCreateComObjectFromReference(ppD3D11device,
                                              out IDXGIDevice3? dxgiDevice,
                                              out Exception? ex))
        {
            throw ex;
        }

        PInvoke.D2D1CreateDevice(
            dxgiDevice,
            in option,
            out nint ppD2D1device).ThrowOnFailure();

        if (!ComMarshal<IWinRTObject>.TryCastComObjectAs(surfaceImageSource,
                                                         out nativeObject,
                                                         out ex))
        {
            throw ex;
        }

        nativeObject.SetDevice(ppD2D1device);
    }

    public static unsafe void BeginDrawNativeSurfaceImageSource(
        ISurfaceImageSourceNativeWithD2D nativeObject,
        Rect updateRect,
        out nint direct3dSurfacePpv)
    {
        nativeObject.BeginDraw(updateRect, in IDXGISurface_IID, out nint dxgiSurfacePpv, out var offset);
        PInvoke.CreateDirect3D11SurfaceFromDXGISurface(dxgiSurfacePpv, out direct3dSurfacePpv);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void MediaPlayer_CopyFrameToVideoSurfaceUnsafe(
        nint playerInstance,
        nint surface)
    {
        ((delegate* unmanaged[Stdcall]<nint, nint, int>)(*(nint*)(*(nint*)playerInstance + 10 * (nint)sizeof(delegate* unmanaged[Stdcall]<nint, nint, int>))))(playerInstance, surface);
    }

    public static unsafe void InitializeD3D11Device(
        IWinRTObject swapChainPanel,
        double xamlScaleFactor,
        ref DXGI_SWAP_CHAIN_DESC1 description,
        out SwapChainContext? swapChainContext)
    {
        Unsafe.SkipInit(out swapChainContext);
        Unsafe.SkipInit(out nint ppSwapChainP);

        CreateD3D11Device(FeatureLevels,
            out nint ppd3d11Device,
            out var d3d11Device,
            out var d3d11DeviceContext,
            out var dxgiDevice,
            out var d2d1Device,
            out var d2d1DeviceContext,
            out var d2d1Factory);

        dxgiDevice.GetAdapter(out IDXGIAdapter dxgiAdapter); // Device -> Adapter
        dxgiAdapter.GetParent(in IDXGIFactory_IID, out nint dxgiFactoryPpv); // Adapter -> Factory
        if (!ComMarshal<IDXGIFactory4>.TryCreateComObjectFromReference(dxgiFactoryPpv,
                                              out IDXGIFactory4? dxgiFactory,
                                              out Exception? ex))
        {
            throw ex;
        }

        // Factory -> SwapChain
        // Create SwapChain and assign it to the SwapChainPanel
        dxgiFactory.CreateSwapChainForComposition(ppd3d11Device, in description, null, out IDXGISwapChain1? dxgiSwapChain);
        if (!ComMarshal<IWinRTObject>.TryCastComObjectAs(swapChainPanel,
                                              out ISwapChainPanelNative? swapChainPanelNative,
                                              out ex,
                                              true))
        {
            throw ex;
        }
        swapChainPanelNative.SetSwapChain(dxgiSwapChain); // Set SwapChain

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
        if (!ComMarshal<IDXGISwapChain1>.TryCastComObjectAs(dxgiSwapChain,
                                              out IDXGISwapChain2? dxgiSwapChain2,
                                              out ex,
                                              true))
        {
            throw ex;
        }

        dxgiSwapChain2.SetMatrixTransform(in inverseScale);

        D2D1_BITMAP_PROPERTIES1 bitmapProperties = default;
        bitmapProperties.dpiX = (float)(96f * xamlScaleFactor);
        bitmapProperties.dpiY = (float)(96f * xamlScaleFactor);
        bitmapProperties.bitmapOptions = D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_CANNOT_DRAW;
        bitmapProperties.pixelFormat = new D2D1_PIXEL_FORMAT
        {
            format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
            alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
        };

        // Direct2D needs the DXGI version of the backbuffer surface pointer.
        dxgiSwapChain2.GetBuffer(0, in IDXGISurface_IID, out IDXGISurface? dxgiSurface);

        if (!ComMarshal<IDXGISurface>.TryCastComObjectAs(dxgiSurface,
                                              out ID3D11Texture2D? d3d11Texture2D,
                                              out ex,
                                              true))
        {
            throw ex;
        }

        // Get a D2D surface from the DXGI back buffer to use as the D2D render target.
        d2d1DeviceContext.CreateBitmapFromDxgiSurface(dxgiSurface, nint.Zero, out ID2D1Bitmap1 d2d1Bitmap);
        d2d1DeviceContext.SetDpi(bitmapProperties.dpiX, bitmapProperties.dpiY);
        d2d1DeviceContext.SetTarget(d2d1Bitmap);

        ComWrappers.TryGetComInstance(dxgiSurface,
            out nint dxgiSurfacePpv);

        // Prepare IDirect3DSurface
        PInvoke.CreateDirect3D11SurfaceFromDXGISurface(dxgiSurfacePpv, out nint d3dSurfacePpv).ThrowOnFailure();
        IDirect3DSurface d3dSurface = MarshalInterface<IDirect3DSurface>.FromAbi(d3dSurfacePpv);

        // Return result
        swapChainContext = new SwapChainContext
        {
            D3D11Device = d3d11Device,
            D3D11DeviceContext = d3d11DeviceContext,
            D2D1Device = d2d1Device,
            D2D1DeviceContext = d2d1DeviceContext,
            D2D1Bitmap = d2d1Bitmap,
            D2D1Factory = d2d1Factory,
            D3D11Texture2D = d3d11Texture2D,
            Direct3DSurface = d3dSurface,
            DXGIDevice = dxgiDevice,
            DXGIFactory = dxgiFactory,
            DXGISwapChain = dxgiSwapChain2,
            DXGISurface = dxgiSurface,
            SwapChainPanelNative = swapChainPanelNative
        };
    }

    private static unsafe void CreateD3D11Device(
        ReadOnlySpan<D3D_FEATURE_LEVEL> featureLevels,
        out nint ppD3D11device,
        out ID3D11Device3 d3d11Device,
        out ID3D11DeviceContext3 d3d11DeviceContext,
        out IDXGIDevice3 dxgiDevice,
        out ID2D1Device2 d2d1Device,
        out ID2D1DeviceContext2 d2d1DeviceContext,
        out ID2D1Factory3 d2d1Factory)
    {
        Unsafe.SkipInit(out ppD3D11device);
        Unsafe.SkipInit(out d3d11Device);
        Unsafe.SkipInit(out d3d11DeviceContext);
        Unsafe.SkipInit(out dxgiDevice);
        Unsafe.SkipInit(out d2d1Device);
        Unsafe.SkipInit(out d2d1DeviceContext);
        Unsafe.SkipInit(out d2d1Factory);

        D3D11_CREATE_DEVICE_FLAG flags = D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT;
#if DEBUG
        flags |= D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_DEBUG;
#endif

        D3D_FEATURE_LEVEL supportedD3DFeature = default;
        PInvoke.D3D11CreateDevice(
            nint.Zero,
            D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE,
            nint.Zero,
            flags,
            in MemoryMarshal.GetReference(featureLevels),
            featureLevels.Length,
            D3D11_SDK_VERSION,
            out ppD3D11device,
            ref supportedD3DFeature,
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

        CreateD2DFactory(out d2d1Factory);
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
            in ID2D1Factory3_IID,
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

public class SwapChainContext : IDisposable
{
    public ID3D11Device3? D3D11Device { get; init; }
    public ID3D11DeviceContext3? D3D11DeviceContext { get; init; }
    public ID2D1Device2? D2D1Device { get; init; }
    public ID2D1DeviceContext2? D2D1DeviceContext { get; init; }
    public ID2D1Bitmap1? D2D1Bitmap { get; init; }
    public ID2D1Factory3? D2D1Factory { get; init; }

    public ID3D11Texture2D? D3D11Texture2D { get; init; }
    public IDirect3DSurface? Direct3DSurface { get; init; }

    public IDXGIDevice3? DXGIDevice { get; init; }
    public IDXGIFactory4? DXGIFactory { get; init; }
    public IDXGISurface? DXGISurface { get; init; }

    public IDXGISwapChain2? DXGISwapChain { get; init; }
    public ISwapChainPanelNative? SwapChainPanelNative { get; init; }

    public void Dispose()
    {
        SwapChainPanelNative?.SetSwapChain(null);
        D3D11DeviceContext?.OMSetRenderTargets(0, nint.Zero, null);
        D2D1DeviceContext?.SetTarget(null);

        D3D11DeviceContext?.Flush();
        Direct3DSurface?.Dispose();

        ComMarshal<ID3D11Device3>.TryReleaseComObject(D3D11Device, out _);
        ComMarshal<ID3D11DeviceContext3>.TryReleaseComObject(D3D11DeviceContext, out _);
        ComMarshal<ID2D1Device2>.TryReleaseComObject(D2D1Device, out _);
        ComMarshal<ID2D1DeviceContext2>.TryReleaseComObject(D2D1DeviceContext, out _);
        ComMarshal<ID2D1Bitmap1>.TryReleaseComObject(D2D1Bitmap, out _);
        ComMarshal<ID2D1Factory3>.TryReleaseComObject(D2D1Factory, out _);

        ComMarshal<ID3D11Texture2D>.TryReleaseComObject(D3D11Texture2D, out _);
        ComMarshal<IDirect3DSurface>.TryReleaseComObject(Direct3DSurface, out _);

        ComMarshal<IDXGIDevice3>.TryReleaseComObject(DXGIDevice, out _);
        ComMarshal<IDXGIFactory4>.TryReleaseComObject(DXGIFactory, out _);
        ComMarshal<IDXGISurface>.TryReleaseComObject(DXGISurface, out _);

        ComMarshal<IDXGISwapChain2>.TryReleaseComObject(DXGISwapChain, out _);
        ComMarshal<ISwapChainPanelNative>.TryReleaseComObject(SwapChainPanelNative, out _);

        GC.SuppressFinalize(this);
    }
}