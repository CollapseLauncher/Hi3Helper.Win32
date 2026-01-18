using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ManagedTools;

public static class EnumerateGpuNames
{
    public static IEnumerable<IDXGIAdapter1> EnumerateGpuAdapters(IDXGIFactory6 factory)
    {
        uint index = 0;

    StartGo:
        Guid adapterIid = new Guid(DXGIClsId.IDXGIAdapter1);
        HResult result = factory.EnumAdapterByGpuPreference(index,
                                                            DXGI_GPU_PREFERENCE.HighPerformance,
                                                            adapterIid,
                                                            out nint adapterPp);

        index++;

        if (!result.Succeeded)
            yield break;

        if (adapterPp == nint.Zero)
        {
            goto StartGo;
        }

        if (!ComMarshal<IDXGIAdapter1>
               .TryCreateComObjectFromReference(adapterPp,
                                                out IDXGIAdapter1? adapter,
                                                out Exception? adapterError) ||
            adapter == null)
        {
            throw adapterError ?? new COMException();
        }

        yield return adapter;
        goto StartGo;
    }

    public static IEnumerable<IDXGIOutput> EnumerateOutputs(IDXGIAdapter1 adapter)
    {
        uint index = 0;

    StartGo:
        HResult result = adapter.EnumOutputs(index,
                                             out nint outputPp);
        index++;

        if (!result.Succeeded)
            yield break;

        if (outputPp == nint.Zero)
        {
            goto StartGo;
        }

        if (!ComMarshal<IDXGIOutput>
               .TryCreateComObjectFromReference(outputPp,
                                                out IDXGIOutput? output,
                                                out Exception? outputError) ||
            output == null)
        {
            throw outputError ?? new COMException();
        }

        yield return output;
        goto StartGo;
    }

    public static IEnumerable<string> GetEnumerateGpuNames()
    {
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

            foreach (IDXGIAdapter1 adapter in EnumerateGpuAdapters(factory))
            {
                yield return GetDescriptionString(adapter);
                ComMarshal<IDXGIAdapter1>.TryReleaseComObject(adapter,
                                                              out _);
            }
        }
        finally
        {
            if (factory != null)
            {
                ComMarshal<IDXGIFactory6>.TryReleaseComObject(factory,
                                                              out _);
            }
        }

        static unsafe string GetDescriptionString(IDXGIAdapter1 adapter)
        {
            adapter.GetDesc(out DXGI_ADAPTER_DESC desc);
            char* p = desc.Description;

            return Marshal.PtrToStringUni((nint)p) ?? "Unknown Device";
        }
    }
}
