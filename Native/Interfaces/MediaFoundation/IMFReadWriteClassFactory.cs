using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.MediaFoundation;

[Guid("e7fe2e12-661c-40da-92f9-4f002ab67627")]
[GeneratedComInterface]
// https://www.winehq.org/pipermail/wine-devel/2018-May/127138.html
public partial interface IMFReadWriteClassFactory
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateInstanceFromURL(in Guid clsid, [MarshalUsing(typeof(Utf16StringMarshaller))] string? url, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IMFAttributes>))] IMFAttributes? attributes, in Guid riid, out nint ppvObject);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateInstanceFromObject(); // Dummy
}
