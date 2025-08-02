using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.FileDialogCOM
{
    [Guid(IIDGuid.IShellItemArray)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    internal partial interface IShellItemArray
    {
        // Not supported: IBindCtx
        void BindToHandler(nint pbc, ref Guid rbhid, ref Guid riid, out nint ppvOut);

        void GetPropertyStore(int flags, ref Guid riid, out nint ppv);

        void GetPropertyDescriptionList(ref PROPERTYKEY keyType, ref Guid riid, out nint ppv);

        void GetAttributes(SIATTRIBFLAGS dwAttribFlags, uint sfgaoMask, out uint psfgaoAttribs);

        void GetCount(out uint pdwNumItems);

        void GetItemAt(uint dwIndex, out IShellItem? ppsi);

        void EnumItems(out nint ppenumShellItems);
    }

    [Guid(IIDGuid.IFileOpenDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    internal partial interface IFileOpenDialog
    {
        [PreserveSig]
        int Show(nint parent);

        void SetFileTypes(uint cFileTypes, nint rgFilterSpec);

        void SetFileTypeIndex(uint iFileType);

        void GetFileTypeIndex(out uint piFileType);

        void Advise(IFileDialogEvents pfde, out uint pdwCookie);

        void Unadvise(uint dwCookie);

        void SetOptions(FOS fos);

        void GetOptions(out FOS pfos);

        void SetDefaultFolder(IShellItem psi);

        void SetFolder(IShellItem psi);

        void GetFolder(out IShellItem ppsi);

        void GetCurrentSelection(out IShellItem ppsi);

        void SetFileName(nint pszName);

        void GetFileName(out nint pszName);

        void SetTitle(nint pszTitle);

        void SetOkButtonLabel(nint pszText);

        void SetFileNameLabel(nint pszLabel);

        void GetResult(out IShellItem ppsi);

        // Argument: IShellItem psi, FileDialogCustomPlace (no longer available) fdcp
        void AddPlace(IShellItem psi, nint fdcp);

        void SetDefaultExtension(nint pszDefaultExtension);

        void Close(int hr);

        void SetClientGuid(ref Guid guid);

        void ClearClientData();

        void SetFilter(nint pFilter);

        void GetResults(out IShellItemArray ppenum);

        void GetSelectedItems(out IShellItemArray ppsai);
    }

    [Guid(IIDGuid.IFileSaveDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper)]
    internal partial interface IFileSaveDialog
    {
        [PreserveSig]
        int Show(nint parent);

        void SetFileTypes(uint cFileTypes, nint rgFilterSpec);

        void SetFileTypeIndex(uint iFileType);

        void GetFileTypeIndex(out uint piFileType);

        void Advise(IFileDialogEvents pfde, out uint pdwCookie);

        void Unadvise(uint dwCookie);

        void SetOptions(FOS fos);

        void GetOptions(out FOS pfos);

        void SetDefaultFolder(IShellItem psi);

        void SetFolder(IShellItem psi);

        void GetFolder(out IShellItem ppsi);

        void GetCurrentSelection(out IShellItem ppsi);

        void SetFileName(nint pszName);

        void GetFileName(out nint pszName);

        void SetTitle(nint pszTitle);

        void SetOkButtonLabel(nint pszText);

        void SetFileNameLabel(nint pszLabel);

        void GetResult(out IShellItem ppsi);

        // Argument: IShellItem psi, FileDialogCustomPlace (no longer available) fdcp
        void AddPlace(IShellItem psi, nint fdcp);

        void SetDefaultExtension(nint pszDefaultExtension);

        void Close([MarshalAs(UnmanagedType.Error)] int hr);

        void SetClientGuid(ref Guid guid);

        void ClearClientData();

        void SetFilter(nint pFilter);

        void SetSaveAsItem(IShellItem psi);

        void SetProperties(nint pStore);

        void SetCollectedProperties(nint pList, int fAppendDefault);

        void GetProperties(out nint ppStore);

        void ApplyProperties(IShellItem psi, nint pStore, ref nint windowHandle, nint pSink);
    }

    [Guid(IIDGuid.IFileDialogEvents)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    internal partial interface IFileDialogEvents; // This dialog is no longer being used

    [Guid(IIDGuid.IShellItem)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    internal partial interface IShellItem
    {
        void BindToHandler(nint pbc, ref Guid bhid, ref Guid riid, out nint ppv);

        void GetParent(out IShellItem ppsi);

        void GetDisplayName(SIGDN sigdnName, out nint ppszName);

        void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);

        void Compare(IShellItem psi, uint hint, out int piOrder);
    }
}
