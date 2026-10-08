using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;
using Hi3Helper.Win32.Native.Enums;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IShellItem)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IShellItem
{
    void BindToHandler(nint pbc, in Guid bhid, in Guid riid, out nint ppv);

    void GetParent(out IShellItem ppsi);

    void GetDisplayName(SIGDN sigdnName, out string? ppszName);

    void GetAttributes(SFGAOF sfgaoMask, out SFGAOF psfgaoAttribs);

    void Compare(IShellItem psi, SICHINTF hint, out int piOrder);
}
