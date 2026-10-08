using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IShellItemArray)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IShellItemArray
{
    void BindToHandler(nint pbc, in Guid rbhid, in Guid riid, out nint ppvOut);

    void GetPropertyStore(GETPROPERTYSTOREFLAGS flags, ref Guid riid, out nint ppv);

    void GetPropertyDescriptionList(in PropertyKey keyType, in Guid riid, out nint ppv);

    void GetAttributes(SIATTRIBFLAGS dwAttribFlags, uint sfgaoMask, out uint psfgaoAttribs);

    void GetCount(out uint pdwNumItems);

    void GetItemAt(uint dwIndex, out IShellItem? ppsi);

    void EnumItems(out nint ppenumShellItems);
}
