using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable ClassNeverInstantiated.Global

namespace Hi3Helper.Win32.Screen;

public static class ScreenProp
{
    public static Size CurrentResolution { get => GetScreenSize(); }

    public static IEnumerable<Size> EnumerateScreenSizes()
    {
        int index = 0;
        int found = 0;
        int sizeOfDevMode = Marshal.SizeOf<DEVMODEW>();

        int lastWidth = 0;
        int lastHeight = 0;
        while (PInvoke.EnumDisplaySettings(null, index, out DEVMODEW mode))
        {
            ++index;
            if (lastWidth == mode.dmPelsWidth && lastHeight == mode.dmPelsHeight)
            {
                continue;
            }

            ++found;
            lastWidth = (int)mode.dmPelsWidth;
            lastHeight = (int)mode.dmPelsHeight;
            yield return new(lastWidth, lastHeight);
        }

        if (found == 0)
        {
            yield return GetScreenSize();
        }
    }

    public static int GetMaxHeight() => EnumerateScreenSizes().Max(x => x.Height);

    private static Size GetScreenSize() =>
        new Size
    {
        Width = PInvoke.GetSystemMetrics(SystemMetric.SM_CXSCREEN),
        Height = PInvoke.GetSystemMetrics(SystemMetric.SM_CYSCREEN)
    };

    public static double GetCurrentDisplayRefreshRate(nint hwnd)
    {
        nint currentMonitor = PInvoke.MonitorFromWindow(hwnd, 2);

        Guid adapterFactoryIid = new Guid(DXGIClsId.IDXGIFactory6);
        PInvoke.CreateDXGIFactory2(0, in adapterFactoryIid, out nint factoryPp)
               .ThrowOnFailure();

        Unsafe.SkipInit(out IDXGIFactory6? factory);
        try
        {
            if (!ComMarshal<IDXGIFactory6>.TryCreateComObjectFromReference(factoryPp,
                                                                           out factory,
                                                                           out Exception? factoryError) ||
                factory == null)
            {
                throw factoryError ?? new COMException();
            }

            foreach (IDXGIAdapter1 adapter in EnumerateGpuNames.EnumerateGpuAdapters(factory))
            {
                try
                {
                    foreach (IDXGIOutput output in EnumerateGpuNames.EnumerateOutputs(adapter))
                    {
                        try
                        {
                            HResult hr = output.GetDesc(out DXGI_OUTPUT_DESC desc);
                            if (desc.Monitor != currentMonitor)
                            {
                                continue;
                            }

                            if (GetRefreshRateFromDXGIOutputDesc(output, ref desc, out double refreshRate))
                            {
                                return refreshRate;
                            }
                        }
                        finally
                        {
                            ComMarshal<IDXGIOutput>.TryReleaseComObject(output, out _);
                        }
                    }
                }
                finally
                {
                    ComMarshal<IDXGIAdapter1>.TryReleaseComObject(adapter, out _);
                }
            }
        }
        finally
        {
            if (factory != null)
            {
                ComMarshal<IDXGIFactory6>.TryReleaseComObject(factory, out _);
            }
        }

        return 60d;
    }

    private static unsafe bool GetRefreshRateFromDXGIOutputDesc(IDXGIOutput output, ref DXGI_OUTPUT_DESC desc, out double refreshRate)
    {
        const int ENUM_CURRENT_SETTINGS = -1;

        refreshRate = 60d;
        MONITORINFOEXW monitorInfo = new();
        if (!PInvoke.GetMonitorInfo(desc.Monitor, ref monitorInfo))
        {
            return false;
        }

        string deviceName = monitorInfo.DeviceNameSpan.ToString();
        if (!PInvoke.EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, out DEVMODEW mode))
        {
            return false;
        }

        bool useDefaultRefreshRate = 1 == mode.dmDisplayFrequency || 0 == mode.dmDisplayFrequency;

        DXGI_MODE_DESC requestDesc = default;
        requestDesc.Width = mode.dmPelsWidth;
        requestDesc.Height = mode.dmPelsHeight;
        requestDesc.RefreshRate.Numerator = useDefaultRefreshRate ? 0 : mode.dmDisplayFrequency;
        requestDesc.RefreshRate.Denominator = useDefaultRefreshRate ? 0u : 1u;
        requestDesc.Format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;
        requestDesc.ScanlineOrdering = DXGI_MODE_SCANLINE_ORDER.DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED;
        requestDesc.Scaling = DXGI_MODE_SCALING.DXGI_MODE_SCALING_UNSPECIFIED;

        output.FindClosestMatchingMode(in requestDesc, out DXGI_MODE_DESC availableDesc, nint.Zero);

        refreshRate = availableDesc.RefreshRate;
        return true;
    }
}
