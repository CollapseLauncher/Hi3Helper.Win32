using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        private static nint          _parentHandler = nint.Zero;
        private static SemaphoreSlim _semaphore     = new(1, 1);

        public static void InitHandlerPointer(nint handle) => _parentHandler = handle;

        public static async Task<string> GetFilePicker(Dictionary<string, string>? fileTypeFilter = null, string? title = null) =>
            (string)await GetPickerOpenTask<string>(string.Empty, fileTypeFilter, title);

        public static async Task<string[]> GetMultiFilePicker(Dictionary<string, string>? fileTypeFilter = null, string? title = null) =>
            (string[])await GetPickerOpenTask<string[]>(Array.Empty<string>(), fileTypeFilter, title, true);

        public static async Task<string> GetFolderPicker(string? title = null) =>
            (string)await GetPickerOpenTask<string>(string.Empty, null, title, false, true);

        public static async Task<string[]> GetMultiFolderPicker(string? title = null) =>
            (string[])await GetPickerOpenTask<string[]>(Array.Empty<string>(), null, title, true, true);

        public static async Task<string> GetFileSavePicker(Dictionary<string, string>? fileTypeFilter = null, string? title = null) =>
            await GetPickerSaveTask<string>(string.Empty, fileTypeFilter, title);

        private static IFileOpenDialog? _sharedFileOpenDialog;
        private static IFileSaveDialog? _sharedFileSaveDialog;

        private static async Task<object> GetPickerOpenTask<T>(object defaultValue, Dictionary<string, string>? fileTypeFilter = null,
            string? title = null, bool isMultiple = false, bool isFolder = false)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await Task.Factory.StartNew(Impl);
            }
            finally
            {
                _semaphore.Release();
            }

            object Impl()
            {
                if (_sharedFileOpenDialog == null)
                {
                    if (!ComMarshal<IFileOpenDialog>.TryCreateComObject(new Guid(CLSIDGuid.FileOpenDialog),
                                                                       CLSCTX.CLSCTX_INPROC_SERVER,
                                                                       out _sharedFileOpenDialog,
                                                                       out Exception? exception))
                    {
                        throw exception;
                    }
                }

                if (title != null) _sharedFileOpenDialog.SetTitle(GetStringPointer(title));
                COMDLG_FILTERSPEC[] filterArray = SetFileTypeFilter(fileTypeFilter);
                if (filterArray.Length > 0)
                {
                    _sharedFileOpenDialog.SetFileTypes((uint)filterArray.Length,
                                                        Marshal.UnsafeAddrOfPinnedArrayElement(filterArray, 0));
                }

                FOS mode = isMultiple
                    ? FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT | FOS.FOS_ALLOWMULTISELECT
                    : FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT;

                if (isFolder)
                {
                    mode |= FOS.FOS_PICKFOLDERS;
                }

                _sharedFileOpenDialog.SetOptions(mode);
                if (_sharedFileOpenDialog.Show(_parentHandler) < 0)
                {
                    return defaultValue;
                }

                if (isMultiple)
                {
                    _sharedFileOpenDialog.GetResults(out IShellItemArray resShell);
                    return GetIShellItemArray(resShell);
                }
                else
                {
                    _sharedFileOpenDialog.GetResult(out IShellItem resShell);
                    resShell.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);
                    return ComPtrToUnicodeString(resultPtr) ?? "";
                }
            }
        }

        private static Task<string> GetPickerSaveTask<T>(string defaultValue, Dictionary<string, string>? fileTypeFilter = null, string? title = null)
        {
            return Task.Factory.StartNew(Impl);

            string Impl()
            {
                if (_sharedFileSaveDialog == null)
                {
                    if (!ComMarshal<IFileSaveDialog>.TryCreateComObject(new Guid(CLSIDGuid.FileOpenDialog),
                                                                        CLSCTX.CLSCTX_INPROC_SERVER,
                                                                        out _sharedFileSaveDialog,
                                                                        out Exception? exception))
                    {
                        throw exception;
                    }
                }

                if (title != null) _sharedFileSaveDialog.SetTitle(GetStringPointer(title));
                COMDLG_FILTERSPEC[] filterArray = SetFileTypeFilter(fileTypeFilter);
                if (filterArray.Length > 0)
                {
                    _sharedFileSaveDialog.SetFileTypes((uint)filterArray.Length,
                                                       Marshal.UnsafeAddrOfPinnedArrayElement(filterArray, 0));
                }

                const FOS mode = FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT;

                _sharedFileSaveDialog.SetOptions(mode);
                if (_sharedFileSaveDialog.Show(_parentHandler) < 0)
                {
                    return defaultValue;
                }

                _sharedFileSaveDialog.GetResult(out IShellItem resShell);
                resShell.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);
                return ComPtrToUnicodeString(resultPtr) ?? "";
            }
        }

        private static COMDLG_FILTERSPEC[] SetFileTypeFilter(Dictionary<string, string>? fileTypeFilter)
        {
            if (fileTypeFilter == null)
            {
                return [];
            }

            int                 len   = fileTypeFilter.Count;
            int                 i     = 0;
            COMDLG_FILTERSPEC[] array = new COMDLG_FILTERSPEC[len];
            foreach (KeyValuePair<string, string> entry in fileTypeFilter)
            {
                array[i++] = new COMDLG_FILTERSPEC
                {
                    pszName = GetStringPointer(entry.Key),
                    pszSpec = GetStringPointer(entry.Value)
                };
            }

            return array;
        }

        private static unsafe nint GetStringPointer(string str)
        {
            fixed (void* ptr = &Utf16StringMarshaller.GetPinnableReference(str))
            {
                return (nint)ptr;
            }
        }

        private static string? ComPtrToUnicodeString(nint ptr)
        {
            try
            {
                string? result = Marshal.PtrToStringUni(ptr);
                return result;
            }
            finally
            {
                if (ptr != nint.Zero)
                    Marshal.FreeCoTaskMem(ptr);
            }
        }

        private static string[] GetIShellItemArray(IShellItemArray? itemArray)
        {
            IShellItem? item = null;
            nint resPtr = nint.Zero;
            uint fileCount = 0;

            itemArray?.GetCount(out fileCount);
            string[] results = new string[fileCount];

            for (uint i = 0; i < fileCount; i++)
            {
                itemArray?.GetItemAt(i, out item);
                item?.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out resPtr);

                if (resPtr != nint.Zero)
                    results[i] = ComPtrToUnicodeString(resPtr) ?? "";
            }

            return results;
        }
    }
}
