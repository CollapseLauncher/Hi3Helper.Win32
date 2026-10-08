using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IModalWindow)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IModalWindow
{
    void Show(nint handleWindowOwner);
}
