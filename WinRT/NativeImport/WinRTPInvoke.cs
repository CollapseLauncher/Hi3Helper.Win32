using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.WinRT.NativeImport;

internal static partial class WinRTPInvoke
{
    [LibraryImport("Shcore.dll", EntryPoint = "CreateStreamOverRandomAccessStream")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static partial int CreateStreamOverRandomAccessStream(
        nint randomAccessStreamPpv,
        ref readonly Guid riid,
        out nint ppv);
}
