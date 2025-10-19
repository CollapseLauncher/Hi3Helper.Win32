using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct COMDLG_FILTERSPEC
    {
        public nint pszName;
        public nint pszSpec;
    }
}
