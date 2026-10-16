using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Enums.WIC;

[Flags]
public enum WICComponentType : uint
{
    WICDecoder                   = 0x1,
    WICEncoder                   = 0x2,
    WICPixelFormatConverter      = 0x4,
    WICMetadataReader            = 0x8,
    WICMetadataWriter            = 0x10,
    WICPixelFormat               = 0x20,
    WICAllComponents             = 0x3f,
    WICCOMPONENTTYPE_FORCE_DWORD = 0x7fffffff
}
