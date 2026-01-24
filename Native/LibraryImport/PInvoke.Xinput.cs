using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport;

public static partial class PInvoke
{
    [LibraryImport("xinput1_4.dll", EntryPoint = "XInputGetState")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.I4)]
    public static partial int XInputGetState(
        int dwUserIndex,
        out XINPUT_STATE pState);
}