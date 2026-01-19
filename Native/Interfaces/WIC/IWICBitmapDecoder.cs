using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[Guid("9EDDE9E7-8DEE-47EA-99DF-E6FAF2ED44BF")]
[GeneratedComInterface]
// https://doxygen.reactos.org/de/d25/interfaceIWICBitmapDecoder.html
public partial interface IWICBitmapDecoder
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult QueryCapability(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Initialize(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetContainerFormat(out Guid pguidContainerFormat);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetDecoderInfo(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CopyPalette(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetMetadataQueryReader(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetPreview(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetColorContexts(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetThumbnail(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetFrameCount(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetFrame(); // Dummy
}
