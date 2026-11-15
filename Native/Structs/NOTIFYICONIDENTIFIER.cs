using System;
using System.Runtime.InteropServices;
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct NOTIFYICONIDENTIFIER
{
    private readonly uint _size;
    private readonly nint _windowHandle;
    private readonly uint _id;
    private readonly Guid _guid;

    public unsafe NOTIFYICONIDENTIFIER(Guid guid)
    {
        _size = (uint)sizeof(NOTIFYICONIDENTIFIER);
        _guid = guid;
    }
}
