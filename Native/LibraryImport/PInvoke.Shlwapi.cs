using System.Runtime.InteropServices;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;

namespace Hi3Helper.Win32.Native.LibraryImport;

public static unsafe partial class PInvoke
{
    [LibraryImport("shlwapi.dll", EntryPoint = "SHCreateStreamOnFileEx", StringMarshalling = StringMarshalling.Utf16)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static partial HResult SHCreateStreamOnFileEx(
        string path,
        STGM   mode,
        uint   attributes,
        BOOL   create,
        nint   template,
        out nint stream);

    [LibraryImport("shlwapi.dll", EntryPoint = "SHCreateMemStream")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static partial nint SHCreateMemStream(byte* data, uint size);
}
