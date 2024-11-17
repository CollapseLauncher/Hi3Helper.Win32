using Hi3Helper.Win32.Native;
using Hi3Helper.Win32.Native.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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
        private static nint parentHandler = nint.Zero;
        public static void InitHandlerPointer(nint handle) => parentHandler = handle;

        public static async ValueTask<string> GetFilePicker(Dictionary<string, string>? FileTypeFilter = null, string? title = null) =>
            (string)await GetPickerOpenTask<string>(string.Empty, FileTypeFilter, title);

        public static async ValueTask<string[]> GetMultiFilePicker(Dictionary<string, string>? FileTypeFilter = null, string? title = null) =>
            (string[])await GetPickerOpenTask<string[]>(Array.Empty<string>(), FileTypeFilter, title, true);

        public static async ValueTask<string> GetFolderPicker(string? title = null) =>
            (string)await GetPickerOpenTask<string>(string.Empty, null, title, false, true);

        public static async ValueTask<string[]> GetMultiFolderPicker(string? title = null) =>
            (string[])await GetPickerOpenTask<string[]>(Array.Empty<string>(), null, title, true, true);

        public static async ValueTask<string> GetFileSavePicker(Dictionary<string, string>? FileTypeFilter = null, string? title = null) =>
            await GetPickerSaveTask<string>(string.Empty, FileTypeFilter, title);

        private static ValueTask<object> GetPickerOpenTask<T>(object defaultValue, Dictionary<string, string>? FileTypeFilter = null,
            string? title = null, bool isMultiple = false, bool isFolder = false)
        {
            CoCreateInstance.CreateInstance(
                new Guid(CLSIDGuid.FileOpenDialog),
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
                out IFileOpenDialog? dialog).ThrowOnFailure();

            nint titlePtr = nint.Zero;

            try
            {
                if (title != null) dialog!.SetTitle(titlePtr = UnicodeStringToCOMPtr(title));
                SetFileTypeFilter(dialog, FileTypeFilter);

                FOS mode = isMultiple ? FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT | FOS.FOS_ALLOWMULTISELECT :
                                        FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT;

                if (isFolder) mode |= FOS.FOS_PICKFOLDERS;

                dialog!.SetOptions(mode);
                if (dialog.Show(parentHandler) < 0) return new ValueTask<object>(defaultValue);

                if (isMultiple)
                {
                    IShellItemArray resShell;
                    dialog.GetResults(out resShell);
                    return new ValueTask<object>(GetIShellItemArray(resShell));
                }
                else
                {
                    IShellItem resShell;
                    dialog.GetResult(out resShell);
                    resShell!.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);
                    return new ValueTask<object>(COMPtrToUnicodeString(resultPtr) ?? "");
                }
            }
            finally
            {
                if (titlePtr != nint.Zero) Marshal.FreeCoTaskMem(titlePtr);
                // Free the COM instance
                CoCreateInstance.FreeInstance(dialog);
            }
        }

        private static ValueTask<string> GetPickerSaveTask<T>(string defaultValue, Dictionary<string, string>? FileTypeFilter = null, string? title = null)
        {
            CoCreateInstance.CreateInstance(
                new Guid(CLSIDGuid.FileSaveDialog),
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
                out IFileSaveDialog? dialog).ThrowOnFailure();

            nint titlePtr = nint.Zero;

            try
            {
                if (title != null) dialog!.SetTitle(titlePtr = UnicodeStringToCOMPtr(title));
                SetFileTypeFilter(dialog, FileTypeFilter);

                FOS mode = FOS.FOS_NOREADONLYRETURN | FOS.FOS_DONTADDTORECENT;

                dialog!.SetOptions(mode);
                if (dialog.Show(parentHandler) < 0) return new ValueTask<string>(defaultValue);

                IShellItem resShell;
                dialog.GetResult(out resShell);
                resShell!.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out nint resultPtr);
                return new ValueTask<string>(COMPtrToUnicodeString(resultPtr) ?? "");
            }
            finally
            {
                if (titlePtr != nint.Zero) Marshal.FreeCoTaskMem(titlePtr);
                // Free the COM instance
                CoCreateInstance.FreeInstance(dialog);
            }
        }

        private static void SetFileTypeFilter(IFileOpenDialog? dialog, Dictionary<string, string>? FileTypeFilter)
        {
            if (FileTypeFilter != null)
            {
                int len = FileTypeFilter.Count;
                int i = 0;
                COMDLG_FILTERSPEC[] array = new COMDLG_FILTERSPEC[len];
                foreach (KeyValuePair<string, string> entry in FileTypeFilter)
                    array[i++] = new COMDLG_FILTERSPEC { pszName = entry.Key, pszSpec = entry.Value };

                nint structPtr = ArrayToHGlobalPtr(array);
                dialog?.SetFileTypes((uint)len, structPtr);
                Marshal.FreeHGlobal(structPtr);
            }
        }

        private static void SetFileTypeFilter(IFileSaveDialog? dialog, Dictionary<string, string>? fileTypeFilter)
        {
            if (fileTypeFilter != null)
            {
                int len = fileTypeFilter.Count;
                int i = 0;
                COMDLG_FILTERSPEC[] array = new COMDLG_FILTERSPEC[len];
                foreach (KeyValuePair<string, string> entry in fileTypeFilter)
                    array[i++] = new COMDLG_FILTERSPEC { pszName = entry.Key, pszSpec = entry.Value };

                nint structPtr = ArrayToHGlobalPtr(array);
                dialog?.SetFileTypes((uint)len, structPtr);
                Marshal.FreeHGlobal(structPtr);
            }
        }

        private static nint ArrayToHGlobalPtr<T>(T[] array)
        {
            int sizeOf = Marshal.SizeOf<T>();

            nint structPtr = Marshal.AllocHGlobal(sizeOf * array!.Length);
            long partPtrLong = structPtr.ToInt64();
            for (int i = 0; i < array.Length; i++)
            {
                nint partPtr = new nint(partPtrLong);
                Marshal.StructureToPtr(array[i]!, partPtr, false);
                partPtrLong += sizeOf;
            }

            return structPtr;
        }

        private static nint UnicodeStringToCOMPtr(string str) => Marshal.StringToCoTaskMemUni(str);

        private static string? COMPtrToUnicodeString(nint ptr)
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
                    results[i] = COMPtrToUnicodeString(resPtr) ?? "";
            }

            return results;
        }
    }
}
