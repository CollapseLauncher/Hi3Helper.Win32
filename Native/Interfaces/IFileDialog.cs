using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.FileDialogCOM;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(IIDGuid.IFileDialog)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IFileDialog : IModalWindow
{
    void SetFileTypes(uint countFileTypes, ref COMDLG_FILTERSPEC rgFilterSpec);

    void SetFileTypeIndex(uint iFileType);

    void GetFileTypeIndex(out uint piFileType);

    void Advise(IFileDialogEvents? pfde, out uint pdwCookie);

    void Unadvise(uint dwCookie);

    void SetOptions(FILEOPENDIALOGOPTIONS fileopendialogoptions);

    void GetOptions(out FILEOPENDIALOGOPTIONS pfos);

    void SetDefaultFolder(IShellItem? psi);

    void SetFolder(IShellItem? psi);

    void GetFolder(out IShellItem ppsi);

    void GetCurrentSelection(out IShellItem ppsi);

    void SetFileName(string pszName);

    void GetFileName(out string pszName);

    void SetTitle(string pszTitle);

    void SetOkButtonLabel(string pszText);

    void SetFileNameLabel(string pszLabel);

    void GetResult(out IShellItem ppsi);

    void AddPlace(IShellItem? psi, FDAP fdap);

    void SetDefaultExtension(string pszDefaultExtension);

    void Close(HResult hr);

    void SetClientGuid(in Guid guid);

    void ClearClientData();

    void SetFilter(IShellItemFilter? pFilter);
}
