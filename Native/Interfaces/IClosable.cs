using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Structs;
#pragma warning disable CS0658 // Not a recognized attribute location

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[Guid("30d5a829-7fa4-4026-83bb-d75bae4ea99e")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface IClosable : IInspectable
{
    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Error)]
    HResult Close();
}
