using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.ShellLinkCOM;
using System;

namespace Hi3Helper.Win32.Native.Structs;

public unsafe struct STATSTG
{
    public char* pwcsName;
    public uint type;
    public ulong cbSize;
    public FileTime mtime;
    public FileTime ctime;
    public FileTime atime;
    public STGM grfMode;
    public uint grfLocksSupported;
    public Guid clsid;
    public uint grfStateBits;
    public uint reserved;
}