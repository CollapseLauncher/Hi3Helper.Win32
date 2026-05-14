using Hi3Helper.Win32.Native.Enums.WIC;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[Guid("EC5EC8A9-C395-4314-9C77-54D7A935FF70")]
[GeneratedComInterface]
// https://doxygen.reactos.org/da/d19/interfaceIWICImagingFactory.html
public partial interface IWICImagingFactory
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoderFromFilename([MarshalUsing(typeof(Utf16StringMarshaller))] string? wzFilename, nint pguidVendor, uint dwDesiredAccess, WICDecodeOptions metadataOptions, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapDecoder>))] out IWICBitmapDecoder? ppIDecoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoderFromStream(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoderFromFileHandle(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateComponentInfo(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoder(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateEncoder(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreatePalette(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateFormatConverter(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapScaler(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapClipper(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFlipRotator(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateStream(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateColorContext(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateColorTransformer(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmap(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromSource(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromSourceRect(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromMemory(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromHBITMAP(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromHICON(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateComponentEnumerator(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateFastMetadataEncoderFromDecoder(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateFastMetadataEncoderFromFrameDecode(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateQueryWriter(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateQueryWriterFromReader(); // Dummy
}
