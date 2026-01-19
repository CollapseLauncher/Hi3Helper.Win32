using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.MediaFoundation;

[Guid("44AE0FA8-EA31-4109-8D2E-4CAE4997C555")]
[GeneratedComInterface]
// https://doxygen.reactos.org/d1/d40/interfaceIMFMediaType.html
public partial interface IMFMediaType : IMFAttributes
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetMajorType(out Guid pguidMajorType);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult IsCompressedFormat([MarshalAs(UnmanagedType.Bool)] out bool pfCompressed);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult IsEqual([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IMFMediaType>))] IMFMediaType? pIMediaType, out uint pdwFlags);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetRepresentation(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult FreeRepresentation(); // Dummy
}
