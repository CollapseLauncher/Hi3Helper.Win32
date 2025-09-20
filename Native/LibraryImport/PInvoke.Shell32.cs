using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.LibraryImport
{
    // ReSharper disable once RedundantUnsafeContext
    public static unsafe partial class PInvoke
    {
        [LibraryImport("shell32.dll", EntryPoint = "ExtractIconExW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial uint ExtractIconEx(string lpszFile, int nIconIndex, nint phiconLarge, nint phiconSmall, uint nIcons);

        [LibraryImport("shell32.dll", EntryPoint = "SHFileOperationW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int SHFileOperation(in SHFILEOPSTRUCTW fileOp);

        [LibraryImport("shell32.dll", EntryPoint = "SHGetFileInfoW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial nint SHGetFileInfo(
            string pszPath,
            int    dwFileAttributes,
            nint   psfi,
            uint   cbFileInfo,
            uint   uFlags);

        [LibraryImport("shell32.dll", SetLastError = true, EntryPoint = "SetCurrentProcessExplicitAppUserModelID", StringMarshalling = StringMarshalling.Utf16)]
        public static partial HResult SetProcessAumid(string appUserModelId);

        [LibraryImport("shell32.dll", SetLastError = true, EntryPoint = "GetCurrentProcessExplicitAppUserModelID", StringMarshalling = StringMarshalling.Utf16)]
        public static partial HResult GetProcessAumid(out string? appUserModelId);

        [LibraryImport("shell32.dll", EntryPoint = "SHGetKnownFolderPath", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int SHGetKnownFolderPath(in Guid rfid, uint dwFlags, nint hToken, out string? ppszPath);
    }
}
