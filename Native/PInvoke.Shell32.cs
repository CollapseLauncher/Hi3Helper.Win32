using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public static unsafe partial class PInvoke
    {
        [LibraryImport("shell32.dll", EntryPoint = "ExtractIconExW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial uint ExtractIconEx(string lpszFile, int nIconIndex, nint[]? phiconLarge, nint[]? phiconSmall, uint nIcons);

        [LibraryImport("shell32.dll", EntryPoint = "SHFileOperationW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int SHFileOperation(nint fileOp);


        [LibraryImport("shell32", EntryPoint = "SHGetFileInfoW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial nint SHGetFileInfo(
            string pszPath,
            int dwFileAttributes,
            nint psfi,
            uint cbFileInfo,
            uint uFlags);
    }
}
