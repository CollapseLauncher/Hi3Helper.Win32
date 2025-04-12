using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", StringMarshalling = StringMarshalling.Utf16)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool MiniDumpWriteDump(
            IntPtr     hProcess,
            int        processId,
            SafeHandle hFile,
            int        dumpType,
            IntPtr     exceptionParam,
            IntPtr     userStreamParam,
            IntPtr     callbackParam);
    }
}