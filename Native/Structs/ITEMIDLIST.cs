using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ITEMIDLIST
{
    public SHITEMID mkid;
}