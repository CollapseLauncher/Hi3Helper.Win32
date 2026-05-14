using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("47dd575d-ac05-4cdd-8049-9b02cd16f44c")]
public partial interface ID2D1Device : ID2D1Resource
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-createdevicecontext
    void CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS options, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1DeviceContext>))] out ID2D1DeviceContext deviceContext);

    // https://learn.microsoft.com/windows/win32/Direct2D/id2d1device-createprintcontrol
    void CreatePrintControl(/*[MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICImagingFactory>))] IWICImagingFactory*/ nint wicFactory, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IPrintDocumentPackageTarget>))] IPrintDocumentPackageTarget documentTarget, nint /* optional D2D1_PRINT_CONTROL_PROPERTIES* */ printControlProperties, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1PrintControl>))] out ID2D1PrintControl printControl);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-setmaximumtexturememory
    [PreserveSig]
    void SetMaximumTextureMemory(ulong maximumInBytes);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-getmaximumtexturememory
    [PreserveSig]
    ulong GetMaximumTextureMemory();

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-clearresources
    [PreserveSig]
    void ClearResources(uint millisecondsSinceUse);
}
