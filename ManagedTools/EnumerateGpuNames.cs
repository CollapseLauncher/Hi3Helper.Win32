using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ManagedTools;

public static class EnumerateGpuNames
{
    public static IEnumerable<IDXGIAdapter1> EnumerateGpuAdapters(IDXGIFactory6 factory)
    {
        uint index = 0;

    StartGo:
        Guid adapterIid = new(DXGIClsId.IDXGIAdapter1);
        HResult result = factory
           .EnumAdapterByGpuPreference(index,
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
                                                out Exception? adapterError))
        {
            throw adapterError;
        }

        yield return adapter;
        goto StartGo;
    }

    public static IEnumerable<IDXGIOutput> EnumerateOutputs(IDXGIAdapter1 adapter)
    {
        uint index = 0;

    StartGo:
        HResult result = adapter.EnumOutputs(index, out nint outputPp);
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
                                                out Exception? outputError))
        {
            throw outputError;
        }

        yield return output;
        goto StartGo;
    }

    public static IEnumerable<string> GetEnumerateGpuNames()
    {
        Guid adapterFactoryIid = new(DXGIClsId.IDXGIFactory6);
        PInvoke.CreateDXGIFactory2(0, in adapterFactoryIid, out IDXGIFactory2? factory)
               .ThrowOnFailure();

        if (!ComMarshal<IDXGIFactory2>.TryCastComObjectAs(factory!,
                                                          out IDXGIFactory6? factory6,
                                                          out Exception? ex))
        {
            throw ex;
        }
        
        foreach (IDXGIAdapter1 adapter in EnumerateGpuAdapters(factory6))
        {
            yield return GetDescriptionString(adapter);
        }

        yield break;

        static unsafe string GetDescriptionString(IDXGIAdapter1 adapter)
        {
            adapter.GetDesc(out DXGI_ADAPTER_DESC desc);
            char* p = desc.Description;

            return Marshal.PtrToStringUni((nint)p) ?? "Unknown Device";
        }
    }
}
