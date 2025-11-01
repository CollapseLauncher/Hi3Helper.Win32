using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.FileDialogCOM
{
    /*
     * Reference:
     * https://www.dotnetframework.org/default.aspx/4@0/4@0/DEVDIV_TFS/Dev10/Releases/RTMRel/ndp/fx/src/WinForms/Managed/System/WinForms/FileDialog_Vista_Interop@cs/1305376/FileDialog_Vista_Interop@cs
     * 
     * UPDATE: 2023-11-01
     * This code has been modified to support ILTrimming and Native AOT
     * by using Source-generated COM Wrappers on .NET 8.
     * 
     * Please refer to this link for more information:
     * https://learn.microsoft.com/en-us/dotnet/standard/native-interop/comwrappers-source-generation
     */
    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    public static class FileDialogNative
    {
        private static          nint          _parentHandler = nint.Zero;
        private static readonly SemaphoreSlim Semaphore      = new SemaphoreSlim(1, 1);

        private static readonly Guid FileOpenDialogGuid = new Guid(CLSIDGuid.FileOpenDialog);
        private static readonly Guid FileSaveDialogGuid = new Guid(CLSIDGuid.FileSaveDialog);

        public static void InitHandlerPointer(nint handle) => _parentHandler = handle;

        public static async Task<string> GetFilePicker(
            Dictionary<string, string>? fileTypeFilter = null,
            string?                     title          = null)
        {
            object? result = await GetPickerOpenTask<string?>("", fileTypeFilter, title);
            if (result is string str)
            {
                return str;
            }

            return "";
        }

        public static async Task<string[]> GetMultiFilePicker(
            Dictionary<string, string>? fileTypeFilter = null,
            string?                     title          = null)
        {
            object? result = await GetPickerOpenTask<string[]>(Array.Empty<string>(), fileTypeFilter, title, true);
            if (result is string[] str)
            {
                return str;
            }

            return [];
        }

        public static async Task<string> GetFolderPicker(string? title = null)
        {
            object? result = await GetPickerOpenTask<string>("", null, title, false, true);
            if (result is string str)
            {
                return str;
            }

            return "";
        }

        public static async Task<string[]> GetMultiFolderPicker(string? title = null)
        {
            object? result = await GetPickerOpenTask<string[]>(Array.Empty<string>(), null, title, true, true);
            if (result is string[] str)
            {
                return str;
            }

            return [];
        }

        public static async Task<string> GetFileSavePicker(
            Dictionary<string, string>? fileTypeFilter = null,
            string?                     title          = null)
        {
            string? result = await GetPickerSaveTask<string?>("", fileTypeFilter, title);
            return result ?? "";
        }

        private static async Task<object?> GetPickerOpenTask<T>(
            object?                     defaultValue   = null,
            Dictionary<string, string>? fileTypeFilter = null,
            string?                     title          = null,
            bool                        isMultiple     = false,
            bool                        isFolder       = false)
        {
            await Semaphore.WaitAsync();
            try
            {
                return await Task.Factory.StartNew(Impl) ?? defaultValue;
            }
            finally
            {
                Semaphore.Release();
            }

            object? Impl()
            {
                if (!ComMarshal<IFileOpenDialog>.TryCreateComObject(in FileOpenDialogGuid,
                                                                    CLSCTX.CLSCTX_INPROC_SERVER,
                                                                    out IFileOpenDialog? dialog,
                                                                    out Exception? exception))
                {
                    throw exception;
                }

                ref COMDLG_FILTERSPEC filterArray = ref SetFileTypeFilter(fileTypeFilter, out uint filterCount);
                try
                {
                    if (!string.IsNullOrEmpty(title))
                        dialog.SetTitle(title);

                    if (filterCount > 0)
                        dialog.SetFileTypes(filterCount, ref filterArray);

                    FILEOPENDIALOGOPTIONS mode = isMultiple
                        ? FILEOPENDIALOGOPTIONS.FOS_NOREADONLYRETURN | FILEOPENDIALOGOPTIONS.FOS_DONTADDTORECENT | FILEOPENDIALOGOPTIONS.FOS_ALLOWMULTISELECT
                        : FILEOPENDIALOGOPTIONS.FOS_NOREADONLYRETURN | FILEOPENDIALOGOPTIONS.FOS_DONTADDTORECENT;

                    if (isFolder)
                    {
                        mode |= FILEOPENDIALOGOPTIONS.FOS_PICKFOLDERS;
                    }

                    dialog.SetOptions(mode);
                    if (ShowIsCancelledByUser(dialog))
                    {
                        return null;
                    }

                    if (isMultiple)
                    {
                        dialog.GetResults(out IShellItemArray resShell);
                        return GetIShellItemArray(resShell);
                    }
                    else
                    {
                        dialog.GetResult(out IShellItem resShell);
                        resShell.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);

                        string? result = Marshal.PtrToStringUni(resultPtr);
                        Marshal.FreeCoTaskMem(resultPtr);
                        return result ?? defaultValue;
                    }
                }
                finally
                {
                    _ = ComMarshal<IFileOpenDialog>.TryReleaseComObject(dialog, out _);
                    FreeRefCoTaskMem(ref filterArray);
                }
            }
        }

        private static async Task<string?> GetPickerSaveTask<T>(string? defaultValue, Dictionary<string, string>? fileTypeFilter = null, string? title = null)
        {
            await Semaphore.WaitAsync();
            try
            {
                return await Task.Factory.StartNew(Impl) ?? defaultValue;
            }
            finally
            {
                Semaphore.Release();
            }

            string? Impl()
            {
                if (!ComMarshal<IFileSaveDialog>.TryCreateComObject(in FileSaveDialogGuid,
                                                                    CLSCTX.CLSCTX_INPROC_SERVER,
                                                                    out IFileSaveDialog? dialog,
                                                                    out Exception? exception))
                {
                    throw exception;
                }

                ref COMDLG_FILTERSPEC filterArray = ref SetFileTypeFilter(fileTypeFilter, out uint filterCount);
                try
                {
                    if (!string.IsNullOrEmpty(title))
                        dialog.SetTitle(title);

                    if (filterCount > 0)
                        dialog.SetFileTypes(filterCount, ref filterArray);

                    const FILEOPENDIALOGOPTIONS mode = FILEOPENDIALOGOPTIONS.FOS_NOREADONLYRETURN | FILEOPENDIALOGOPTIONS.FOS_DONTADDTORECENT;

                    dialog.SetOptions(mode);
                    if (ShowIsCancelledByUser(dialog))
                    {
                        return defaultValue;
                    }

                    dialog.GetResult(out IShellItem resShell);
                    resShell.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);

                    string? result = Marshal.PtrToStringUni(resultPtr);
                    Marshal.FreeCoTaskMem(resultPtr);
                    return result ?? defaultValue;
                }
                finally
                {
                    _ = ComMarshal<IFileSaveDialog>.TryReleaseComObject(dialog, out _);
                    FreeRefCoTaskMem(ref filterArray);
                }
            }
        }

        private static bool ShowIsCancelledByUser(IFileDialog dialog)
        {
            try
            {
                dialog.Show(_parentHandler);
                return false;
            }
            catch (COMException ex)
            {
                if (unchecked((uint)ex.HResult) == 0x800704C7u)
                    return true;

                throw;
            }
        }

        private static unsafe void FreeRefCoTaskMem<T>(ref T source)
            where T : unmanaged
        {
            if (Unsafe.IsNullRef(ref source))
            {
                return;
            }

            nint ptr = (nint)Unsafe.AsPointer(ref source);
            Marshal.FreeCoTaskMem(ptr);
        }

        private static unsafe ref COMDLG_FILTERSPEC SetFileTypeFilter(Dictionary<string, string>? fileTypeFilter, out uint count)
        {
            if (fileTypeFilter == null)
            {
                count    = 0;
                return ref Unsafe.NullRef<COMDLG_FILTERSPEC>();
            }

            int len = fileTypeFilter.Count;
            int i   = 0;

            nint ptrAlloc = Marshal.AllocCoTaskMem(len * sizeof(COMDLG_FILTERSPEC));
            COMDLG_FILTERSPEC* array = (COMDLG_FILTERSPEC*)ptrAlloc;

            foreach (KeyValuePair<string, string> entry in fileTypeFilter)
            {
                array[i].pszName   = GetStringPointer(entry.Key);
                array[i++].pszSpec = GetStringPointer(entry.Value);
            }

            count = (uint)len;
            return ref Unsafe.AsRef<COMDLG_FILTERSPEC>(array);
        }

        private static unsafe nint GetStringPointer(string str)
        {
            fixed (void* ptr = &Utf16StringMarshaller.GetPinnableReference(str))
            {
                return (nint)ptr;
            }
        }

        private static string[]? GetIShellItemArray(IShellItemArray itemArray)
        {
            IShellItem? item = null;
            nint resPtr = nint.Zero;

            itemArray.GetCount(out uint fileCount);
            if (fileCount == 0)
            {
                return null;
            }

            string[] results = new string[fileCount];
            for (uint i = 0; i < fileCount; i++)
            {
                itemArray?.GetItemAt(i, out item);
                item?.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out resPtr);

                results[i] = Marshal.PtrToStringUni(resPtr) ?? "";
                if (resPtr != nint.Zero)
                {
                    Marshal.FreeCoTaskMem(resPtr);
                }
            }

            return results;
        }
    }
}
