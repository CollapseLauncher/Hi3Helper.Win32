using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        [LibraryImport("OLE32.dll", EntryPoint = "CoCreateInstance")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult CoCreateInstance(in Guid rclsid, nint pUnkOuter, CLSCTX dwClsContext, in Guid riid, out void* ppObj);
    }
}
