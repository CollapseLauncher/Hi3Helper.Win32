using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.MediaFoundation;

[Guid("2CD2D921-C447-44A7-A13C-4ADABFC247E3")]
[GeneratedComInterface]
// https://doxygen.reactos.org/d3/d9f/interfaceIMFAttributes.html
public partial interface IMFAttributes
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetItem(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetItemType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CompareItem(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Compare(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetUINT32(in Guid guidKey, out uint punValue); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetUINT64(in Guid guidKey, out ulong punValue); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetDouble(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetGUID(in Guid guidKey, out Guid pGuidValue); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetStringLength(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetString(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetAllocatedString(in Guid guidKey, [MarshalUsing(typeof(Utf16StringMarshaller), CountElementName = nameof(pcchLength))] out string? ppwszValue, out uint pcchLength); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetBlobSize(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetBlob(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetAllocatedBlob(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetUnknown(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetItem(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult DeleteItem(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult DeleteAllItems(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetUINT32(in Guid guid, uint unValue); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetUINT64(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetDouble(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetGUID(in Guid guidKey, in Guid guidValue);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetString(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetBlob(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetUnknown(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult LockStore(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult UnlockStore(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetCount(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetItemByIndex(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CopyAllItems(); // Dummy
}
