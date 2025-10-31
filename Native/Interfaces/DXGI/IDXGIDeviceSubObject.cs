using Hi3Helper.Win32.Native.ClassIds.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[Guid(DXGIClsId.IDXGIDeviceSubObject)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public unsafe partial interface IDXGIDeviceSubObject : IDXGIObject
{
    /// <summary>Retrieves the device.</summary>
    /// <param name="riid">
    /// <para>Type: <b>REFIID</b> The reference id for the device.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgidevicesubobject-getdevice#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppDevice">
    /// <para>Type: <b>void**</b> The address of a pointer to the device.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi/nf-dxgi-idxgidevicesubobject-getdevice#parameters">Read more on learn.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/com/structure-of-com-error-codes">HRESULT</a></b> A code that indicates success or failure (see <a href="https://docs.microsoft.com/windows/desktop/direct3ddxgi/dxgi-error">DXGI_ERROR</a>).</para>
    /// </returns>
    /// <remarks>The type of interface that is returned can be any interface published by the device. For example, it could be an IDXGIDevice * called pDevice, and therefore the REFIID would be obtained by calling __uuidof(pDevice).</remarks>\
    void GetDevice(Guid* riid, out void* ppDevice);
}
