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
// ReSharper disable InconsistentNaming

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
            yield return new Size(lastWidth, lastHeight);
        }

        if (found == 0)
        {
            yield return GetScreenSize();
        }
    }

    public static int GetMaxHeight() => EnumerateScreenSizes().Max(x => x.Height);

    private static Size GetScreenSize() =>
        new()
        {
            Width  = PInvoke.GetSystemMetrics(SystemMetric.SM_CXSCREEN),
            Height = PInvoke.GetSystemMetrics(SystemMetric.SM_CYSCREEN)
        };

    public static double GetCurrentDisplayRefreshRate(nint hwnd, out string? monitorPath)
    {
        Unsafe.SkipInit(out monitorPath);
        nint currentMonitor = PInvoke.MonitorFromWindow(hwnd, 2);

        Guid adapterFactoryIid = new(DXGIClsId.IDXGIFactory6);
        PInvoke.CreateDXGIFactory2(0, in adapterFactoryIid, out IDXGIFactory2? factory2)
               .ThrowOnFailure();

        if (!ComMarshal<IDXGIFactory2>.TryCastComObjectAs(factory2!,
                                                          out IDXGIFactory6? factory6,
                                                          out Exception? ex))
        {
            throw ex;
        }

        foreach (IDXGIAdapter1 adapter in EnumerateGpuNames.EnumerateGpuAdapters(factory6))
        {
            foreach (IDXGIOutput output in EnumerateGpuNames.EnumerateOutputs(adapter))
            {
                if (!output.GetDesc(out DXGI_OUTPUT_DESC desc) ||
                    desc.Monitor != currentMonitor)
                {
                    continue;
                }

                if (GetRefreshRateFromDXGIOutputDesc(output, ref desc, out double refreshRate, out monitorPath))
                {
                    return refreshRate;
                }
            }
        }

        return 60d;
    }

    private static bool GetRefreshRateFromDXGIOutputDesc(IDXGIOutput output,
                                                         ref DXGI_OUTPUT_DESC desc,
                                                         out double refreshRate,
                                                         out string? displayPath)
    {
        const int ENUM_CURRENT_SETTINGS = -1;
        Unsafe.SkipInit(out displayPath);

        refreshRate = 60d;
        MONITORINFOEXW monitorInfo = new();
        if (!PInvoke.GetMonitorInfo(desc.Monitor, ref monitorInfo))
        {
            return false;
        }

        string deviceName = monitorInfo.DeviceNameSpan.ToString();
        if (!PInvoke.EnumDisplaySettings(deviceName, ENUM_CURRENT_SETTINGS, out DEVMODEW mode))
        {
            return false;
        }

        bool useDefaultRefreshRate = mode.dmDisplayFrequency is 1 or 0;

        DXGI_MODE_DESC requestDesc = default;
        requestDesc.Width = mode.dmPelsWidth;
        requestDesc.Height = mode.dmPelsHeight;
        requestDesc.RefreshRate.Numerator = useDefaultRefreshRate ? 0 : mode.dmDisplayFrequency;
        requestDesc.RefreshRate.Denominator = useDefaultRefreshRate ? 0u : 1u;
        requestDesc.Format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;
        requestDesc.ScanlineOrdering = DXGI_MODE_SCANLINE_ORDER.DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED;
        requestDesc.Scaling = DXGI_MODE_SCALING.DXGI_MODE_SCALING_UNSPECIFIED;

        if (!output.FindClosestMatchingMode(in requestDesc, out DXGI_MODE_DESC availableDesc, nint.Zero))
        {
            return false;
        }

        displayPath = deviceName;
        refreshRate = availableDesc.RefreshRate;
        return true;
    }
}
