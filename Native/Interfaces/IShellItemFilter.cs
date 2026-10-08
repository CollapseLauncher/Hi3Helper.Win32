using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;
using Hi3Helper.Win32.Native.Enums;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IShellItemFilter)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IShellItemFilter
{
    void IncludeItem(IShellItem psi);

    void GetEnumFlags(out SHCONTF pgrfFlags);
}
