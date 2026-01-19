using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.MediaFoundation;

[Guid("70AE66F2-C809-4E4F-8915-BDCB406B7993")]
[GeneratedComInterface]
// https://www.winehq.org/pipermail/wine-patches/2017-February/158102.html
public partial interface IMFSourceReader
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetStreamSelection(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetStreamSelection(uint dwStreamIndex, [MarshalAs(UnmanagedType.Bool)] bool fSelected); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetNativeMediaType(uint index, int typeIndex, out nint ppvType);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetCurrentMediaType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetCurrentMediaType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetCurrentPosition(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ReadSample(uint dwStreamIndex, uint dwControlFlags, out uint pdwActualStreamIndex, out uint pdwStreamFlags, out uint pllTimestamp, out nint ppSample); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Flush(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetServiceForStream(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetPresentationAttribute(); // Dummy
}
