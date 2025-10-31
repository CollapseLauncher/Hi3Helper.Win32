using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Enums.DXGI;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIFactory5)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIFactory5 : IDXGIFactory4
{
    /// <summary>Used to check for hardware feature support.</summary>
    /// <param name="Feature">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_5/ne-dxgi1_5-dxgi_feature">DXGI_FEATURE</a></b> Specifies one member of  <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_5/ne-dxgi1_5-dxgi_feature">DXGI_FEATURE</a> to query support for.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pFeatureSupportData">
    /// <para>Type: <b>void*</b> Specifies a pointer to a buffer that will be filled with data that describes the feature support.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="FeatureSupportDataSize">
    /// <para>Type: <b>UINT</b> The size, in bytes, of <i>pFeatureSupportData</i>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> This method returns an HRESULT success or error code.</para>
    /// </returns>
    /// <remarks>Refer to the description of <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/ne-dxgi-dxgi_swap_chain_flag">DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING</a>.</remarks>
    void CheckFeatureSupport(DXGI_FEATURE Feature, void* pFeatureSupportData, uint FeatureSupportDataSize);
}
