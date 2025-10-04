using System;
using System.Runtime.InteropServices;
using Hi3Helper.Win32.Native.Enums;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool MiniDumpWriteDump(
            IntPtr       hProcess,
            int          processId,
            nint         hFile,
            MiniDumpType dumpType,
            IntPtr       exceptionParam,
            IntPtr       userStreamParam,
            IntPtr       callbackParam);
    }
}