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
                yield return "Unknown Device";
                goto StartGo;
            }

            Unsafe.SkipInit(out IDXGIAdapter1? adapter);

            try
            {
                if (!ComMarshal<IDXGIAdapter1>
                       .TryCreateComObjectFromReference(adapterPp,
                                                        out adapter,
                                                        out Exception? adapterError) ||
                    adapter == null)
                {
                    throw adapterError ?? new COMException();
                }

                yield return GetDescriptionString(adapter);
            }
            finally
            {
                if (adapter != null)
                {
                    ComMarshal<IDXGIAdapter1>.TryReleaseComObject(adapter,
                                                                  out _);
                }
            }

            goto StartGo;
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
