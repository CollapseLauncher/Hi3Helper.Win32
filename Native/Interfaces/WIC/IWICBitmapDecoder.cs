using Hi3Helper.Win32.Native.Enums.WIC;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[GeneratedComInterface]
[Guid("9EDDE9E7-8DEE-47EA-99DF-E6FAF2ED44BF")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// https://doxygen.reactos.org/de/d25/interfaceIWICBitmapDecoder.html
public partial interface IWICBitmapDecoder
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult QueryCapability(nint stream, out uint capabilities);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Initialize(nint stream, WICDecodeOptions cacheOptions);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetContainerFormat(out Guid format);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetDecoderInfo(out nint info);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CopyPalette(nint palette);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetMetadataQueryReader(out nint reader);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetPreview(out nint source);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetColorContexts(uint count, nint* contexts, out uint actualCount);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetThumbnail(out nint source);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetFrameCount(out uint count);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetFrame(uint index, out nint frame);
}
