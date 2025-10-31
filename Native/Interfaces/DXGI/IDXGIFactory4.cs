using Hi3Helper.Win32.Native.ClassIds.DXGI;
using Hi3Helper.Win32.Native.Structs.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIFactory4)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIFactory4 : IDXGIFactory3
{
    /// <summary>Outputs the IDXGIAdapter for the specified LUID.</summary>
    /// <param name="AdapterLuid">
    /// <para>Type: <b><a href="https://docs.microsoft.com/previous-versions/windows/hardware/drivers/ff549708(v=vs.85)">LUID</a></b> A unique value that identifies the adapter. See <a href="https://docs.microsoft.com/previous-versions/windows/hardware/drivers/ff549708(v=vs.85)">LUID</a> for a definition of the structure. <b>LUID</b> is defined in dxgi.h.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumadapterbyluid#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="riid">
    /// <para>Type: <b>REFIID</b> The globally unique identifier (GUID) of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> object referenced by the <i>ppvAdapter</i> parameter.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumadapterbyluid#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppvAdapter">
    /// <para>Type: <b>void**</b> The address of an <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> interface pointer to the adapter. This parameter must not be NULL.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumadapterbyluid#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns S_OK if successful; an error code otherwise. For a list of error codes, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>. See also Direct3D 12 Return Codes.</para>
    /// </returns>
    /// <remarks>
    /// <para>For Direct3D 12, it's no longer possible to backtrack from a device to the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> that was used to create it. <b>IDXGIFactory4::EnumAdapterByLuid</b> enables an app to retrieve information about the adapter where a D3D12 device was created. <b>IDXGIFactory4::EnumAdapterByLuid</b> is designed to be paired with <a href="https://docs.microsoft.com/windows/desktop/api/d3d12/nf-d3d12-id3d12device-getadapterluid">ID3D12Device::GetAdapterLuid</a>. For more information, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-1-4-improvements">DXGI 1.4 Improvements</a>.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumadapterbyluid#">Read more on learn.microsoft.com</see>.</para>
    /// </remarks>
    void EnumAdapterByLuid(LUID AdapterLuid, Guid* riid, out nint ppvAdapter);

    /// <summary>Provides an adapter which can be provided to D3D12CreateDevice to use the WARP renderer.</summary>
    /// <param name="riid">
    /// <para>Type: <b>REFIID</b> The globally unique identifier (GUID) of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> object referenced by the <i>ppvAdapter</i> parameter.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumwarpadapter#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppvAdapter">
    /// <para>Type: <b>void**</b> The address of an <a href="https://docs.microsoft.com/windows/desktop/api/dxgi/nn-dxgi-idxgiadapter">IDXGIAdapter</a> interface pointer to the adapter. This parameter must not be NULL.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumwarpadapter#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> Returns S_OK if successful; an error code otherwise. For a list of error codes, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>. See also Direct3D 12 Return Codes.</para>
    /// </returns>
    /// <remarks>For more information, see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-1-4-improvements">DXGI 1.4 Improvements</a>.</remarks>
    void EnumWarpAdapter(Guid* riid, out nint ppvAdapter);
}
