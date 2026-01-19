using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.MediaFoundation;

[Guid("7FEE9E9A-4A89-47A6-899C-B6A53A70FB67")]
[GeneratedComInterface]
// https://stackoverflow.com/questions/79738733/media-foundation-com-classes-imfattributes-imfactivate-how-to-use-them-in-a
public partial interface IMFActivate : IMFAttributes
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ActivateObject(in Guid riid, out nint ppv);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ShutdownObject();

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult DetachObject();
}
