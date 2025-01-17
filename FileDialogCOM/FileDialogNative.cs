using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.ManagedTools;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
// ReSharper disable ForCanBeConvertedToForeach

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
        private static nint _parentHandler = nint.Zero;
        public static void InitHandlerPointer(nint handle) => _parentHandler = handle;

        public static async ValueTask<string> GetFilePicker(Dictionary<string, string>? fileTypeFilter = null, string? title = null) =>
            (string)await GetPickerOpenTask<string>(string.Empty, fileTypeFilter, title);

        public static async ValueTask<string[]> GetMultiFilePicker(Dictionary<string, string>? fileTypeFilter = null, string? title = null) =>
            (string[])await GetPickerOpenTask<string[]>(Array.Empty<string>(), fileTypeFilter, title, true);

        public static async ValueTask<string> GetFolderPicker(string? title = null) =>
            (string)await GetPickerOpenTask<string>(string.Empty, null, title, false, true);

        public static async ValueTask<string[]> GetMultiFolderPicker(string? title = null) =>
            (string[])await GetPickerOpenTask<string[]>(Array.Empty<string>(), null, title, true, true);

        public static async ValueTask<string> GetFileSavePicker(Dictionary<string, string>? fileTypeFilter = null, string? title = null) =>
            await GetPickerSaveTask<string>(string.Empty, fileTypeFilter, title);

        private static ValueTask<object> GetPickerOpenTask<T>(object defaultValue, Dictionary<string, string>? fileTypeFilter = null,
            string? title = null, bool isMultiple = false, bool isFolder = false)
        {
            ComMarshal.CreateInstance(
                new Guid(CLSIDGuid.FileOpenDialog),
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
                out IFileOpenDialog? dialog).ThrowOnFailure();

            nint titlePtr = nint.Zero;

            try
            {
                if (title != null) dialog!.SetTitle(titlePtr = UnicodeStringToComPtr(title));
                SetFileTypeFilter(dialog, fileTypeFilter);

                FOS mode = isMultiple ? FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT | FOS.FOS_ALLOWMULTISELECT :
                                        FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT;

                if (isFolder) mode |= FOS.FOS_PICKFOLDERS;

                dialog!.SetOptions(mode);
                if (dialog.Show(_parentHandler) < 0) return new ValueTask<object>(defaultValue);

                if (isMultiple)
                {
                    dialog.GetResults(out var resShell);
                    return new ValueTask<object>(GetIShellItemArray(resShell));
                }
                else
                {
                    dialog.GetResult(out var resShell);
                    resShell.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);
                    return new ValueTask<object>(ComPtrToUnicodeString(resultPtr) ?? "");
                }
            }
            finally
            {
                if (titlePtr != nint.Zero) Marshal.FreeCoTaskMem(titlePtr);
                // Free the COM instance
                ComMarshal.FreeInstance(dialog);
            }
        }

        private static ValueTask<string> GetPickerSaveTask<T>(string defaultValue, Dictionary<string, string>? fileTypeFilter = null, string? title = null)
        {
            ComMarshal.CreateInstance(
                new Guid(CLSIDGuid.FileSaveDialog),
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
                out IFileSaveDialog? dialog).ThrowOnFailure();

            nint titlePtr = nint.Zero;

            try
            {
                if (title != null) dialog!.SetTitle(titlePtr = UnicodeStringToComPtr(title));
                SetFileTypeFilter(dialog, fileTypeFilter);

                const FOS mode = FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT;

                dialog!.SetOptions(mode);
                if (dialog.Show(_parentHandler) < 0) return new ValueTask<string>(defaultValue);

                dialog.GetResult(out var resShell);
                resShell.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);
                return new ValueTask<string>(ComPtrToUnicodeString(resultPtr) ?? "");
            }
            finally
            {
                if (titlePtr != nint.Zero) Marshal.FreeCoTaskMem(titlePtr);
                // Free the COM instance
                ComMarshal.FreeInstance(dialog);
            }
        }

        private static void SetFileTypeFilter(IFileOpenDialog? dialog, Dictionary<string, string>? fileTypeFilter)
        {
            if (fileTypeFilter == null)
            {
                return;
            }

            int                 len   = fileTypeFilter.Count;
            int                 i     = 0;
            COMDLG_FILTERSPEC[] array = new COMDLG_FILTERSPEC[len];
            foreach (KeyValuePair<string, string> entry in fileTypeFilter)
            {
                array[i++] = new COMDLG_FILTERSPEC
                {
                    pszName = UnicodeStringToComPtr(entry.Key),
                    pszSpec = UnicodeStringToComPtr(entry.Value)
                };
            }

            nint structPtr = ArrayToHGlobalPtr(array);
            dialog?.SetFileTypes((uint)len, structPtr);
            Marshal.FreeHGlobal(structPtr);
        }

        private static void SetFileTypeFilter(IFileSaveDialog? dialog, Dictionary<string, string>? fileTypeFilter)
        {
            if (fileTypeFilter == null)
            {
                return;
            }

            int                 len   = fileTypeFilter.Count;
            int                 i     = 0;
            COMDLG_FILTERSPEC[] array = new COMDLG_FILTERSPEC[len];
            foreach (KeyValuePair<string, string> entry in fileTypeFilter)
            {
                array[i++] = new COMDLG_FILTERSPEC
                {
                    pszName = UnicodeStringToComPtr(entry.Key),
                    pszSpec = UnicodeStringToComPtr(entry.Value)
                };
            }

            nint structPtr = ArrayToHGlobalPtr(array);
            dialog?.SetFileTypes((uint)len, structPtr);
            Marshal.FreeHGlobal(structPtr);
        }

        private static unsafe nint ArrayToHGlobalPtr<T>(T[] array)
            where T : unmanaged
        {
            int  bufferSize = sizeof(T) * array.Length;
            nint structPtr  = Marshal.AllocHGlobal(bufferSize);
            fixed (void* arrayPtr = &MemoryMarshal.GetArrayDataReference(array))
            {
                Buffer.MemoryCopy(arrayPtr,
                                  (void*)structPtr,
                                  bufferSize,
                                  bufferSize);
            }

            return structPtr;
        }

        private static nint UnicodeStringToComPtr(string str) => Marshal.StringToCoTaskMemUni(str);

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
