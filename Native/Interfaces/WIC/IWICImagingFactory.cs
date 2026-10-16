using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Enums.WIC;
using Hi3Helper.Win32.Native.Interfaces.D2D;
using Hi3Helper.Win32.Native.Structs;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("EC5EC8A9-C395-4314-9C77-54D7A935FF70")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// https://learn.microsoft.com/windows/win32/api/wincodec/nn-wincodec-iwicimagingfactory
// https://doxygen.reactos.org/da/d19/interfaceIWICImagingFactory.html
public partial interface IWICImagingFactory
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoderFromFilename(
        string            wzFilename,
        ref readonly Guid pguidVendor,
        uint              dwDesiredAccess,
        WICDecodeOptions  metadataOptions,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapDecoder>))]
        out IWICBitmapDecoder? ppIDecoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoderFromStream(
        nint              pIStream,
        ref readonly Guid pguidVendor,
        WICDecodeOptions  metadataOptions,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapDecoder>))]
        out IWICBitmapDecoder? ppIDecoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoderFromFileHandle(
        nuint             hFile,
        ref readonly Guid pguidVendor,
        WICDecodeOptions  metadataOptions,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapDecoder>))]
        out IWICBitmapDecoder? ppIDecoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateComponentInfo(in Guid clsidComponent, out nint ppIInfo);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateDecoder(
        in Guid           guidContainerFormat,
        ref readonly Guid pguidVendor,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmapDecoder>))]
        out IWICBitmapDecoder? ppIDecoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateEncoder(
        in Guid           guidContainerFormat,
        ref readonly Guid pguidVendor,
        out nint          ppIEncoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreatePalette(
        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICPalette>))]
        out IWICPalette? ppIPalette);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateFormatConverter(out nint ppIFormatConverter);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapScaler(out nint ppIBitmapScaler);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapClipper(out nint ppIBitmapClipper);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFlipRotator(out nint ppIBitmapFlipRotator);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateStream(out nint ppIWICStream);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateColorContext(
        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICColorContext>))]
        out IWICColorContext? ppIWICColorContext);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateColorTransformer(out nint ppIWICColorTransform);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmap(
        uint                       uiWidth,
        uint                       uiHeight,
        in Guid                    pixelFormat,
        WICBitmapCreateCacheOption option,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))]
        out IWICBitmap? ppIBitmap);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromSource(
        [MarshalUsing(typeof(ComInterfaceMarshaller<IWICBitmapSource>))]
        IWICBitmapSource?          pIBitmapSource,
        WICBitmapCreateCacheOption option,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))]
        out IWICBitmap? ppIBitmap);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromSourceRect(
        [MarshalUsing(typeof(ComInterfaceMarshaller<IWICBitmapSource>))]
        IWICBitmapSource? pIBitmapSource,
        uint               x,
        uint               y,
        uint               width,
        uint               height,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))]
        out IWICBitmap? ppIBitmap);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromMemory(
        uint    uiWidth,
        uint    uiHeight,
        in Guid pixelFormat,
        uint    cbStride,
        uint    cbBufferSize,
        ref readonly byte pbBuffer,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))]
        out IWICBitmap? ppIBitmap);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromHBITMAP(
        nint                        hBitmap,
        nint                        hPalette,
        WICBitmapAlphaChannelOption options,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))]
        out IWICBitmap? ppIBitmap);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateBitmapFromHICON(
        nint hIcon,

        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IWICBitmap>))]
        out IWICBitmap? ppIBitmap);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateComponentEnumerator(
        WICComponentType             componentTypes,
        WICComponentEnumerateOptions options,
        out nint                     ppIEnumUnknown);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateFastMetadataEncoderFromDecoder(
        [MarshalUsing(typeof(ComInterfaceMarshaller<IWICBitmapDecoder>))]
        IWICBitmapDecoder? pIDecoder,
        out nint            ppIFastEncoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateFastMetadataEncoderFromFrameDecode(
        [MarshalUsing(typeof(ComInterfaceMarshaller<IWICBitmapFrameDecode>))]
        IWICBitmapFrameDecode? pIFrameDecoder,
        out nint                ppIFastEncoder);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateQueryWriter(
        in Guid           guidMetadataFormat,
        ref readonly Guid pguidVendor,
        out nint          ppIQueryWriter);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult CreateQueryWriterFromReader(
        nint              pIQueryReader,
        ref readonly Guid pguidVendor,
        out nint          ppIQueryWriter);
}
