using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.ShellLinkCOM;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("ole32.dll", EntryPoint = "CoCreateInstance")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult CoCreateInstance(in Guid rclsid, nint pUnkOuter, CLSCTX dwClsContext, in Guid riid, out void* ppObj);

        /// <summary>
        /// Called to properly clean up the memory referenced by a PropVariant instance.
        /// </summary>
        [LibraryImport("ole32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult PropVariantClear(PropVariant* pvar);
    }
}
