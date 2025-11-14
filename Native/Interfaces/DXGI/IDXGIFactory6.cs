using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable RedundantUnsafeContext
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIFactory6)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIFactory6 : IDXGIFactory5
{
    /// <summary>Enumerates graphics adapters based on a given GPU preference.</summary>
    /// <param name="Adapter">
    /// <para>Type: <b>UINT</b> The index of the adapter to enumerate. The indices are in order of the preference specified in <i>GpuPreference</i>—for example, if <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified, then the highest-performing adapter is at index 0, the second-highest is at index 1, and so on.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="GpuPreference">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_gpu_preference">DXGI_GPU_PREFERENCE</a></b> The GPU preference for the app.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="riid">
    /// <para>Type: <b>REFIID</b> The globally unique identifier (GUID) of the <a href="https://docs.microsoft.com/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgifactory6">IDXGIAdapter</a> object referenced by the <i>ppvAdapter</i> parameter.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppvAdapter">
    /// <para>Type: <b>void**</b> The address of an <a href="https://docs.microsoft.com/windows/win32/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> interface pointer to the adapter. This parameter must not be NULL.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> Returns <b>S_OK</b> if successful; an error code otherwise. For a list of error codes, see <a href="https://docs.microsoft.com/windows/win32/direct3ddxgi/dxgi-error">DXGI_ERROR</a>.</para>
    /// </returns>
    /// <remarks>
    /// <para>This method allows developers to select which GPU they think is most appropriate for each device their app creates and utilizes. This method is similar to <a href="https://docs.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory1-enumadapters1">IDXGIFactory1::EnumAdapters1</a>, but it accepts a GPU preference to reorder the adapter enumeration. It returns the appropriate <b>IDXGIAdapter</b> for the given GPU preference. It is meant to be used in conjunction with the <b>D3D*CreateDevice</b> functions, which take in an <b>IDXGIAdapter*</b>. When <b>DXGI_GPU_PREFERENCE_UNSPECIFIED</b> is specified for the <i>GpuPreference</i> parameter, this method is equivalent to calling <a href="https://docs.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgifactory1-enumadapters1">IDXGIFactory1::EnumAdapters1</a>. When <b>DXGI_GPU_PREFERENCE_MINIMUM_POWER</b> is specified for the <i>GpuPreference</i> parameter, the order of preference for the adapter returned in <i>ppvAdapter</i> will be:<dl> <dd>1. iGPUs (integrated GPUs)</dd> <dd>2. dGPUs (discrete GPUs)</dd> <dd>3. xGPUs (external GPUs)</dd> </dl></para>
    /// <para>When <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified for the <i>GpuPreference</i> parameter, the order of preference for the adapter returned in <i>ppvAdapter</i> will be:<dl> <dd>1. xGPUs</dd> <dd>2. dGPUs</dd> <dd>3. iGPUs</dd> </dl></para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    [PreserveSig]
    int EnumAdapterByGpuPreference(uint Adapter, DXGI_GPU_PREFERENCE GpuPreference, in Guid riid, out nint ppvAdapter);
}
