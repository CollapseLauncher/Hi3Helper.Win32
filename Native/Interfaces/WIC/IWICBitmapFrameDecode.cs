using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.WIC;

[GeneratedComInterface]
[Guid("3B16811B-6A43-4EC9-A813-3D930C13B940")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public unsafe partial interface IWICBitmapFrameDecode : IWICBitmapSource
{
    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetMetadataQueryReader(out nint reader);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetColorContexts(uint count, nint* contexts, out uint actualCount);

    [return: MarshalAs(UnmanagedType.Error)]
    [PreserveSig]
    HResult GetThumbnail(out nint source);
}
