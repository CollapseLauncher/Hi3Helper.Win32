using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IFileSaveDialog)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IFileSaveDialog : IFileDialog
{
    void SetSaveItemAs(IShellItem psi);

    void SetProperties(nint pStore);

    void SetCollectedProperties(nint pList, [MarshalAs(UnmanagedType.Bool)] bool fAppendDefault);

    void GetProperties(out nint ppStore);
}
