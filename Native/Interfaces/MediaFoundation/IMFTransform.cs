using Hi3Helper.Win32.Native.Enums.MediaFoundation;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.MediaFoundation;

[Guid("BF94C121-5B05-4E6F-8000-BA598961414D")]
[GeneratedComInterface]
// https://doxygen.reactos.org/d6/d8c/interfaceIMFTransform.html
public partial interface IMFTransform
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetStreamLimits(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetStreamCount(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetStreamIDs(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetInputStreamInfo(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetOutputStreamInfo(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetAttributes([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IMFAttributes>))] out IMFAttributes? pAttributes); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetInputStreamAttributes(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetOutputStreamAttributes(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult DeleteInputStream(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult AddInputStreams(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetInputAvailableType(uint dwInputStreamID, uint dwTypeIndex, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IMFMediaType>))] out IMFMediaType? ppType); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetOutputAvailableType(uint dwInputStreamID, uint dwTypeIndex, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IMFMediaType>))] out IMFMediaType? ppType); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetInputType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetOutputType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetInputCurrentType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetOutputCurrentType(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetInputStatus(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult GetOutputStatus(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult SetOutputBounds(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ProcessEvent(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ProcessMessage(MFT_MESSAGE_TYPE eMessage, nint ulParam); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ProcessInput(); // Dummy

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult ProcessOutput(); // Dummy
}
