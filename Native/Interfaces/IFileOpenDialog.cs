using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IFileOpenDialog)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IFileOpenDialog : IFileDialog
{
    void GetResults(out IShellItemArray ppenum);

    void GetSelectedItems(out IShellItemArray ppsai);
}
