using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct SHFILEINFOW
    {
        public       nint hIcon;
        public       int  iIcon;
        public       int  dwAttributes;
        public fixed char szDisplayName[260];
        public fixed char szTypeName[80];
    }
}
