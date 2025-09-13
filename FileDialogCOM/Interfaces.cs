using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.FileDialogCOM
{
    [Guid(IIDGuid.IModalWindow)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IModalWindow
    {
        void Show(nint handleWindowOwner);
    }

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

    [Guid(IIDGuid.IFileOpenDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    public partial interface IFileOpenDialog : IFileDialog
    {
        void GetResults(out IShellItemArray ppenum);

        void GetSelectedItems(out IShellItemArray ppsai);
    }

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

    [Guid(IIDGuid.IShellItemFilter)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IShellItemFilter
    {
        void IncludeItem(IShellItem psi);

        void GetEnumFlags(out SHCONTF pgrfFlags);
    }

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

    [Guid(IIDGuid.IFileDialogEvents)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IFileDialogEvents; // This dialog is no longer being used

    [Guid(IIDGuid.IShellItem)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IShellItem
    {
        void BindToHandler(nint pbc, in Guid bhid, in Guid riid, out nint ppv);

        void GetParent(out IShellItem ppsi);

        void GetDisplayName(SIGDN sigdnName, out nint ppszName);

        void GetAttributes(SFGAOF sfgaoMask, out SFGAOF psfgaoAttribs);

        void Compare(IShellItem psi, SICHINTF hint, out int piOrder);
    }
}
