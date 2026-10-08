using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IFileDialogEvents)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IFileDialogEvents; // This dialog is no longer being used
