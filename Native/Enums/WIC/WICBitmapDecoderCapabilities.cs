using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Enums.WIC;

[Flags]
public enum WICBitmapDecoderCapabilities : uint
{
    SameEncoder          = 0x1,
    CanDecodeAllImages   = 0x2,
    CanDecodeSomeImages  = 0x4,
    CanEnumerateMetadata = 0x8,
    CanDecodeThumbnail   = 0x10,
    FORCE_DWORD          = 0x7fffffff
}
